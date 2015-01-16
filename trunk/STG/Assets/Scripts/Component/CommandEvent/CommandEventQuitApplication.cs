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
	[SerializeField]
	private int delay;

	void OnCommandEvent( CommandManager.CommandEventData data )
	{
		data.LockInput();
		FrameRateUtility.StartCoroutine( delay, () =>
		{
			Application.Quit();
		});
	}
}
