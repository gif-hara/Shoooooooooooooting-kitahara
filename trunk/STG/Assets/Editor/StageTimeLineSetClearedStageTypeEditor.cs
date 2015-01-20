/*===========================================================================*/
/*
*     * FileName    : StageTimeLineSetClearedStageTypeEditor.cs
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
[CustomEditor( typeof( StageTimeLineSetClearedStageType ) )]
public class StageTimeLineSetClearedStageTypeEditor : A_StageTimeLineActionEditor<StageTimeLineSetClearedStageType>
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
