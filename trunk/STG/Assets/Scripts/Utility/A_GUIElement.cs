/*===========================================================================*/
/*
*     * FileName    : A_GUIElement.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public abstract class A_GUIElement : GameMonoBehaviour
{
	public int priority = 0;
	
	public abstract void Draw();
	
	protected void Label( string text, params GUILayoutOption[] options )
	{
		GUILayout.Label( text, options );
	}
	
	protected void Horizontal( System.Action func, params GUILayoutOption[] options )
	{
		GUILayout.BeginHorizontal( options );
		func();
		GUILayout.EndHorizontal();
	}
	protected void Vertical( System.Action func, params GUILayoutOption[] options )
	{
		GUILayout.BeginVertical( options );
		func();
		GUILayout.EndVertical();
	}
	protected void Button( string text, System.Action func )
	{
		if( GUILayout.Button( text ) )
		{
			func();
		}
	}
}
