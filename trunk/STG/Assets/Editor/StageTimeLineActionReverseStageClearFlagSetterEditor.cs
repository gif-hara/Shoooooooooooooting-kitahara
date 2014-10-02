/*===========================================================================*/
/*
*     * FileName    : StageTimeLineActionReverseStageClearFlagSetterEditor.cs
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
[CustomEditor( typeof( StageTimeLineActionReverseStageClearFlagSetter ) )]
public class StageTimeLineActionReverseStageClearFlagSetterEditor : A_StageTimeLineActionEditor<StageTimeLineActionReverseStageClearFlagSetter>
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
