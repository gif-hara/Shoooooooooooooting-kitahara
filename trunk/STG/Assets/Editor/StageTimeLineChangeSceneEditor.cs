/*===========================================================================*/
/*
*     * FileName    : StageTimeLineChangeSceneEditor.cs
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
[CustomEditor( typeof( StageTimeLineChangeScene ) )]
public class StageTimeLineChangeSceneEditor : A_StageTimeLineActionEditor<StageTimeLineChangeScene>
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
