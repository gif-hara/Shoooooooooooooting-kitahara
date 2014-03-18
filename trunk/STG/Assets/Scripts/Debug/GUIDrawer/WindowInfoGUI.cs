/*===========================================================================*/
/*
*     * FileName    :WindowInfoGUI.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class WindowInfoGUI : A_GUIElement
{
	public override void Draw ()
	{
		Label( string.Format( "Width = {0} Height = {1}", Screen.width, Screen.height ) );
	}
}
