/*===========================================================================*/
/*
*     * FileName    : InputTogglePause.cs
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
public class InputTogglePause : MonoBehaviour
{
	public const string PauseMessage = "OnPause";

	public const string UnPauseMessage = "OnUnPause";

	void Update ()
	{
		if( Input.GetKeyDown( KeyCode.Escape ) )
		{
			PauseManager.Instance.Toggle();
			string message = PauseManager.Instance.IsPause
				? PauseMessage
				: UnPauseMessage;
			gameObject.BroadcastMessage( message );
		}
	}
}
