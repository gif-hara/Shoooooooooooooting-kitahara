/*===========================================================================*/
/*
*     * FileName    : StageTimeLineSetterEditor.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class StageTimeLineSetterEditor : A_EditorWindowBase
{
	/// <summary>
	/// 実体.
	/// </summary>
	private static StageTimeLineSetterEditor Instance
	{
		get
		{
			return instance ?? (instance = EditorWindow.GetWindow<StageTimeLineSetterEditor>());
		}
	}
	private static StageTimeLineSetterEditor instance;

	private List<GameObject> refGameObjects;

	private int timeLine = 0;

	private Vector2 scrollPosition = Vector2.zero;

	/// <summary>
	/// ウィンドウの生成.
	/// </summary>
	[MenuItem( "Window/StageTimeLineSetter" )]
	private static void CreateWindow()
	{
		instance = EditorWindow.GetWindow<StageTimeLineSetterEditor>();
		instance.title = "StageTimeLineSetter";
	}

	void OnGUI()
	{
		if( refGameObjects == null )
		{
			refGameObjects = new List<GameObject>();
		}

		Button( "Add Selection", () =>
		{
			var selections = Selection.objects;
			for( int i=0; i<selections.Length; i++ )
			{
				var obj = selections[i];
				if( obj.GetType() != typeof( GameObject ) )
				{
					continue;
				}
				if( refGameObjects.Find( m => m == obj ) != null )
				{
					continue;
				}

				refGameObjects.Add( obj as GameObject );
			}
		});

		Button( "Clear", () =>
		{
			refGameObjects.Clear();
		});

		Horizontal( () =>
		{
			timeLine = IntField( timeLine );
			Button( "Set", () =>
			{
				SetTimeLine();
			});
			Button( "Add", () =>
			{
				AddTimeLine( timeLine );
			});
			Button( "Sub", () =>
			{
				AddTimeLine( -timeLine );
			});
		});

		scrollPosition = EditorGUILayout.BeginScrollView( scrollPosition );

		Vertical( () =>
		{
			for( int i=0,imax=refGameObjects.Count; i<imax; i++ )
			{
				refGameObjects[i] = EditorGUILayout.ObjectField( refGameObjects[i], typeof( GameObject ), false ) as GameObject;
			}
		});

		EditorGUILayout.EndScrollView();
	}

	private void SetTimeLine()
	{
		for( int i=0,imax=refGameObjects.Count; i<imax; i++ )
		{
			var stageTimeLineActionable = refGameObjects[i].GetComponent<A_StageTimeLineActionable>();
			if( stageTimeLineActionable == null )
			{
				continue;
			}
			
			stageTimeLineActionable.timeLine = timeLine;
			stageTimeLineActionable.SyncData();
		}
	}
	private void AddTimeLine( int value )
	{
		for( int i=0,imax=refGameObjects.Count; i<imax; i++ )
		{
			var stageTimeLineActionable = refGameObjects[i].GetComponent<A_StageTimeLineActionable>();
			if( stageTimeLineActionable == null )
			{
				continue;
			}
			
			stageTimeLineActionable.timeLine += value;
			stageTimeLineActionable.SyncData();
		}
	}
}