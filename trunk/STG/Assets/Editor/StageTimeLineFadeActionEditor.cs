/*===========================================================================*/
/*
*     * FileName    : FadeActionEditor.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor( typeof( StageTimeLineFadeAction ) )]
public class StageTimeLineFadeActionEditor : A_StageTimeLineActionEditor<StageTimeLineFadeAction>
{
	public override void OnInspectorGUI()
	{
		Enclose( "Property", () =>
		{
			DrawTimeLine();
			DrawDuration();
			DrawColor();
		});
	}
	
	private void DrawDuration()
	{
		Horizontal( () =>
		{
			Target.duration = EditorGUILayout.IntField( "Duration", Target.duration );
		});
	}
	
	private void DrawColor()
	{
		Horizontal( () =>
		{
			Target.fromColor = EditorGUILayout.ColorField( "From", Target.fromColor );
		});
		Horizontal( () =>
		{
			Target.toColor = EditorGUILayout.ColorField( "To", Target.toColor );
		});
	}
}
