/*===========================================================================*/
/*
*     * FileName    : StageTimeLinePlayBGMEditor.cs
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
[CustomEditor( typeof( StageTimeLinePlayBGM ) )]
public class StageTimeLinePlayBGMEditor : A_StageTimeLineActionEditor<StageTimeLinePlayBGM>
{
	public override void OnInspectorGUI()
	{
		Enclose( "Property", () =>
		{
			DrawTimeLine();
			Target.label = EditorGUILayout.TextField( Target.label );
		});
	}

}
