/*===========================================================================*/
/*
*     * FileName    : OnStartContinueGameObjectEnableSetter.cs
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
public class OnStartContinueGameObjectEnableSetter : MonoBehaviour
{
	[SerializeField]
	private GameObject refTarget;

	[SerializeField]
	private bool isActive;

	void OnStartContinue()
	{
		if (GameStatusInterfacer.GameMode == GameDefine.GameModeType.Replay) return;

		refTarget.SetActive( isActive );
	}
}
