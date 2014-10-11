/*===========================================================================*/
/*
*     * FileName    : StageTimeLineFadeBGMEditor.cs
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
[CustomEditor( typeof( StageTimeLineFadeBGM ) )]
public class StageTimeLineFadeBGMEditor : A_StageTimeLineActionEditor<StageTimeLineFadeBGM>
{
	public override void OnInspectorGUI()
	{
		Enclose( "Property", () =>
		{
			DrawTimeLine();
			base.OnInspectorGUI();
		});
	}
}
