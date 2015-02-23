/*===========================================================================*/
/*
*     * FileName    : StageCreator.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[CustomEditor( typeof( StageManager ) )]
public class StageCreator : A_EditorMonoBehaviour<StageManager>
{
	private static List<string> enemyPrefabList = null;
	
	/// <summary>
	/// CreateActionableObjectの描画幅.
	/// </summary>
	private const float CreateActionableObjectWidth = 250.0f;
	
	void OnEnable()
	{
		var enemyCreator = Target.GetComponentsInChildren<StageTimeLineCreateEnemy>();
		AllSyncChildren();
		StringComparer comparer = new StringComparer();
		Target.prefabActionableObjectList.Sort( (x, y) => comparer.Compare( x.gameObject.name, y.gameObject.name ) );
	}
	
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI();
		DrawTimeLine();
		DrawSyncButton();
		Enclose( "Create Actionable Object", () =>
		{
			DrawActionableObject();
		}, true, true );
	}
	
	private void DrawTimeLine()
	{
		Horizontal( () =>
		{
			int oldTimeLine = Target.timeLineManager.TimeLine;
			Target.timeLineManager.TimeLine = EditorGUILayout.IntField( "TimeLine", Target.timeLineManager.TimeLine );
			if( oldTimeLine != Target.timeLineManager.TimeLine )
			{
				SceneView.RepaintAll();
				AllSyncChildren();
			}
		});
	}
	private void DrawActionableObject()
	{
		foreach( var a in Target.prefabActionableObjectList )
		{
			DrawActionableObjectCreateButton( a.gameObject, (obj) =>
			{
				obj.Initialize( Target.timeLineManager.TimeLine );
			});
		}
	}
	/// <summary>
	/// Syncボタンの描画.
	/// </summary>
	private void DrawSyncButton()
	{
		Horizontal( () =>
		{
			Button( "Sync", () =>
			{
				Target.actionableListManager.ActionableList = new List<A_StageTimeLineActionable>();
				for( int i=0,imax=Target.transform.childCount; i<imax; i++ )
				{
					var creator = Target.Trans.GetChild( i ).GetComponent<A_StageTimeLineActionable>();
					if( creator == null )	continue;
					
					Target.actionableListManager.ActionableList.Add( creator );
				}
				
				Target.actionableListManager.ActionableList.Sort( (x, y) => x.timeLine - y.timeLine );
			});
		});
	}
	/// <summary>
	/// 敵プレハブリストを返す.
	/// </summary>
	/// <value>
	/// The enemy prefab list.
	/// </value>
	public static List<string> EnemyPrefabList
	{
		get
		{
			if( enemyPrefabList == null )
			{
				enemyPrefabList = new List<string>( Directory.GetFiles( Directory.GetCurrentDirectory() + "/Assets/Prefabs/Enemy" ) );
				for( int i=0,imax=enemyPrefabList.Count; i<imax; i++ )
				{
#if UNITY_EDITOR_OSX
					int slashIndex = enemyPrefabList[i].LastIndexOf( "/" ) + 1;

#else
					int slashIndex = enemyPrefabList[i].LastIndexOf( "\\" );
#endif


					enemyPrefabList[i] = enemyPrefabList[i].Substring( slashIndex );
					enemyPrefabList[i] = enemyPrefabList[i].Replace( ".prefab", "" );
				};

			}
			
			return enemyPrefabList;
		}
	}
	/// <summary>
	/// A_StageTimeLineActionableオブジェクトの生成ボタンの描画と初期化.
	/// </summary>
	/// <param name='prefab'>
	/// Prefab.
	/// </param>
	/// <param name='initialFunc'>
	/// Initial func.
	/// </param>
	private void DrawActionableObjectCreateButton( GameObject prefab, System.Action<A_StageTimeLineActionable> initialFunc )
	{
		Horizontal( () =>
		{
			Label( prefab.name, Width( CreateActionableObjectWidth ) );
			Button( "Create", () =>
			{
				// オブジェクトの生成.
				var obj = Instantiate( prefab ) as GameObject;
				obj.transform.parent = Target.transform;
				
				// Actionableオブジェクトの初期化.
				var actionable = obj.GetComponent<A_StageTimeLineActionable>();
				actionable.Initialize( Target.timeLineManager.TimeLine );
				
				// あとは各々で初期化が必要な場合は処理をする.
				initialFunc( actionable );
				
				// 生成したゲームオブジェクトをInspectorに表示する.
				Selection.activeGameObject = obj;
			});
		});
	}
	
	private void AllSyncChildren()
	{
		Target.actionableListManager.AllSync();
	}
}
