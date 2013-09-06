/*===========================================================================*/
/*
*     * FileName    : A_EditorBase.cs
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
using System;


public class A_EditorBase : Editor
{
	protected void Horizontal( Action func, params GUILayoutOption[] options )
	{
		EditorGUILayout.BeginHorizontal( options );
		func();
		EditorGUILayout.EndHorizontal();
	}
	protected void Vertical( Action func, params GUILayoutOption[] options )
	{
		EditorGUILayout.BeginVertical( options );
		func();
		EditorGUILayout.EndVertical();
	}
	
	protected void Button( string text, System.Action func, params GUILayoutOption[] options )
	{
		if( GUILayout.Button( text, options ) )
		{
			func();
		}
	}
	
	protected void Label( string text, params GUILayoutOption[] options )
	{
		GUILayout.Label( text, options );
	}
	
	protected void Space()
	{
		EditorGUILayout.Space();
	}
	
	protected GUILayoutOption Width( float width )
	{
		return GUILayout.Width( width );
	}
	
	protected int IntField( int value, params GUILayoutOption[] options )
	{
		return EditorGUILayout.IntField( value, options );
	}
	
	protected int IntField( string label, int value, params GUILayoutOption[] options )
	{
		return EditorGUILayout.IntField( label, value, options );
	}
	
	protected void Enclose( string label, System.Action func, bool isDrawTopLine = false, bool isDrawUnderLine = true )
	{
		if( isDrawTopLine )
		{
			Line();
		}
		Label( label );
		EditorGUI.indentLevel++;
		func();
		EditorGUI.indentLevel--;
		if( isDrawUnderLine )
		{
			Line();
		}
	}
	
	protected void Line()
	{
		GUILayout.Box( "", GUILayout.ExpandWidth( true ), GUILayout.Height( 2 ) );
	}
}
