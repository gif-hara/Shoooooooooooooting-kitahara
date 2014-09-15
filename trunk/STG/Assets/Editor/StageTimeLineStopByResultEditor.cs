/*===========================================================================*/
/*
*     * FileName    : StageTimeLineStopByResultEditor.cs
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
[CustomEditor( typeof( StageTimeLineStopByResult ) )]
public class StageTimeLineStopByResultEditor : A_StageTimeLineActionEditor<StageTimeLineStopByResult>
{
	public override void OnInspectorGUI()
	{
		Enclose( "Property", () =>
		{
			DrawTimeLine();
		});
	}
}
