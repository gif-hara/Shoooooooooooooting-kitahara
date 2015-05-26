/*===========================================================================*/
/*
*     * FileName    : StageTimeLineBroadcastMessageInLayerEditor.cs
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
[CustomEditor( typeof( StageTimeLineBroadcastMessageInLayer ) )]
public class StageTimeLineBroadcastMessageInLayerEditor : A_StageTimeLineActionEditor<StageTimeLineBroadcastMessageInLayer>
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
