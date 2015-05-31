/*===========================================================================*/
/*
*     * FileName    : OnPauseGameObjectEnableSetter.cs
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
public class OnPauseGameObjectEnableSetter : MonoBehaviour
{
	[SerializeField]
	private GameObject refTarget;

	[SerializeField]
	private bool isPauseActive;

	void OnPause()
	{
		refTarget.SetActive( isPauseActive );
		Debug.Log( refTarget.name, refTarget );
	}

	void OnUnPause()
	{
		refTarget.SetActive( !isPauseActive );
	}
}
