/*===========================================================================*/
/*
*     * FileName    : CommandEventUnPause.cs
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
public class CommandEventUnPause : MonoBehaviour
{
	[SerializeField]
	private GameObject refBroadcastObject;

	void OnCommandEvent()
	{
		PauseManager.Instance.UnPause();
		refBroadcastObject.BroadcastMessage( InputTogglePause.UnPauseMessage );
	}
}
