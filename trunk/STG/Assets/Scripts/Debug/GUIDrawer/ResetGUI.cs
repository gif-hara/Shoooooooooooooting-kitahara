/*===========================================================================*/
/*
*     * FileName    : ResetGUI.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ResetGUI : A_GUIElement
{
	public string sceneName;
	
	public override void Draw()
	{
		Button( "Reset", () =>
		{
			Reset();
		});
	}
	public void Reset()
	{
		Application.LoadLevel( sceneName );
	}
}
