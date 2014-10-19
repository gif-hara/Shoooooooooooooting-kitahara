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
		refTarget.SetActive( isActive );
	}
}
