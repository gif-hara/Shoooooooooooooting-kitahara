/*===========================================================================*/
/*
*     * FileName    : StageTimeLineSceneChangePracticeModeEditor.cs
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
[CustomEditor( typeof( StageTimeLineSceneChangePracticeMode ) )]
public class StageTimeLineSceneChangePracticeModeEditor : A_StageTimeLineActionEditor<StageTimeLineSceneChangePracticeMode>
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		Enclose( "Property", () =>
		        {
			DrawTimeLine();
		});
	}
}
