/*===========================================================================*/
/*
*     * FileName    : StageTimeLineStartResultEditor.cs
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
[CustomEditor( typeof( StageTimeLineStartResult ) )]
public class StageTimeLineStartResultEditor : A_StageTimeLineActionEditor<StageTimeLineStartResult>
{
	public override void OnInspectorGUI()
	{
		Enclose( "Property", () =>
		{
			DrawTimeLine();
		});
	}
}
