/*===========================================================================*/
/*
*     * FileName    : StageTimeLinePrefabCreateActionEditor.cs
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

[CustomEditor( typeof( StageTimeLinePrefabCreateAction ) )]
public class StageTimeLinePrefabCreateActionEditor : A_StageTimeLineActionEditor<StageTimeLinePrefabCreateAction>
{
	public override void OnInspectorGUI()
	{
		Enclose( "Property", () =>
		{
			DrawTimeLine();
			
			var tmpPrefab = Target.prefab;
			Target.prefab = EditorGUILayout.ObjectField( "Prefab", Target.prefab, typeof( GameObject ), true ) as GameObject;
			
			if( tmpPrefab != Target.prefab )
			{
				Target.SyncData();
			}
		});
	}
}
