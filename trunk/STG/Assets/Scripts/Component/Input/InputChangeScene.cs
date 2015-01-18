﻿/*===========================================================================*/
/*
*     * FileName    : InputChangeScene.cs
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
public class InputChangeScene : ChangeScene
{
	void Update ()
	{
		if( MyInput.FireKeyDown )
		{
			Change();
		}
	}
}
