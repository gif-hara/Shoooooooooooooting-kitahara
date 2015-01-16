/*===========================================================================*/
/*
*     * FileName    : OnStartContinuePause.cs
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
public class OnStartContinuePause : MonoBehaviour
{
	void OnStartContinue()
	{
		PauseManager.Instance.Pause();
	}
}
