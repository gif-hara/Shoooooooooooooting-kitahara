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
	private const float CreateActionableObjectWidth = 140.0f;
	
	void OnEnable()
	{
		var enemyCreator = Target.GetComponentsInChildren<EnemyCreator>();
		foreach( var e in enemyCreator )
		{
			e.isIconDraw = false;
		}
	}
	
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI();
		DrawTimeLine();
		Enclose( "Create Actionable Object", () =>
		{
			DrawCreateEnemyCreatorButton();
			DrawFadeActionButton();
			DrawStopActionButton();
		}, true, true );
		DrawSyncButton();
	}
	
	private void DrawTimeLine()
	{
		Horizontal( () =>
		{
			int oldTimeLine = Target.timeLine;
			Target.timeLine = EditorGUILayout.IntField( "TimeLine", Target.timeLine );
			if( oldTimeLine != Target.timeLine )
			{
				SceneView.RepaintAll();
			}
		});
	}
	/// <summary>
	/// 敵生成アクションプレハブ生成ボタンの描画.
	/// </summary>
	private void DrawCreateEnemyCreatorButton()
	{
		DrawActionableObjectCreateButton( "Enemy Create", Target.prefabEnemyCreator, (obj) =>
		{
			(obj as EnemyCreator).Initialize( 0, Target.timeLine );
		});
	}
	/// <summary>
	/// フェードアクションプレハブ生成ボタンの描画.
	/// </summary>
	private void DrawFadeActionButton()
	{
		DrawActionableObjectCreateButton( "Fade Action", Target.prefabFadeAction, (obj) => {} );
	}
	
	private void DrawStopActionButton()
	{
		DrawActionableObjectCreateButton( "TimeLine Stop Action", Target.prefabStopAction, (obj) => {} );
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
				Target.actionableList = new List<A_StageTimeLineActionable>();
				for( int i=0,imax=Target.transform.childCount; i<imax; i++ )
				{
					var creator = Target.Trans.GetChild( i ).GetComponent<A_StageTimeLineActionable>();
					if( creator == null )	continue;
					
					Target.actionableList.Add( creator );
				}
				
				Target.actionableList.Sort( (x, y) => x.timeLine - y.timeLine );
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
					int slashIndex = enemyPrefabList[i].LastIndexOf( "\\" );
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
	/// <param name='label'>
	/// Label.
	/// </param>
	/// <param name='prefab'>
	/// Prefab.
	/// </param>
	/// <param name='initialFunc'>
	/// Initial func.
	/// </param>
	private void DrawActionableObjectCreateButton( string label, GameObject prefab, System.Action<A_StageTimeLineActionable> initialFunc )
	{
		Horizontal( () =>
		{
			Label( label, Width( CreateActionableObjectWidth ) );
			Button( "Create", () =>
			{
				// オブジェクトの生成.
				var obj = Instantiate( prefab ) as GameObject;
				obj.transform.parent = Target.transform;
				
				// Actionableオブジェクトの初期化.
				var actionable = obj.GetComponent<A_StageTimeLineActionable>();
				actionable.Initialize( Target.timeLine );
				
				// あとは各々で初期化が必要な場合は処理をする.
				initialFunc( actionable );
			});
		});
	}
}
