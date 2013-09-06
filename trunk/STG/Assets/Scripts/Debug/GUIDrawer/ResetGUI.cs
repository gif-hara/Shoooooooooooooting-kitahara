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
	
	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
	}
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
