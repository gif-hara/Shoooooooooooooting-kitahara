/*===========================================================================*/
/*
*     * FileName    : StageTimeLineStartStageEditor.cs
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
[CustomEditor( typeof( StageTimeLineStartStage ) )]
public class StageTimeLineStartStageEditor : A_StageTimeLineActionEditor<StageTimeLineStartStage>
{
	public override void OnInspectorGUI()
	{
		Enclose( "Property", () =>
		{
			DrawTimeLine();
		});
	}
}
