/*===========================================================================*/
/*
*     * FileName    : StageTimeLineStageChangeActionEditor.cs
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

[CustomEditor( typeof( StageTimeLineStageChangeAction ) )]
public class StageTimeLineStageChangeActionEditor : A_StageTimeLineActionEditor<StageTimeLineStageChangeAction>
{
	public override void OnInspectorGUI()
	{
		Enclose( "Property", () =>
		{
			DrawTimeLine();
			
			Target.prefabNextStage = EditorGUILayout.ObjectField( "NextStagePrefab", Target.prefabNextStage, typeof( GameObject ), true ) as GameObject;
			Target.prefabExtensionStage = EditorGUILayout.ObjectField( "ExtensionStagePrefab", Target.prefabExtensionStage, typeof( GameObject ), true ) as GameObject;
			Target.refConditioner = EditorGUILayout.ObjectField( "Conditioner", Target.refConditioner, typeof( A_StageChangeConditioner ), true ) as A_StageChangeConditioner;
		});
	}
}
