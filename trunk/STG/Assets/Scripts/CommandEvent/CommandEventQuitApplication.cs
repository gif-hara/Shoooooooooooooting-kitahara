/*===========================================================================*/
/*
*     * FileName    : CommandEventQuitApplication.cs
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
public class CommandEventQuitApplication : MonoBehaviour
{
	void OnCommandEvent( CommandManager.CommandEventData data )
	{
		data.LockInput();
		Application.Quit();
	}
}
