/*===========================================================================*/
/*
*     * FileName    : PlayerSelectModeGameObjectEnableSetter.cs
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
public class PlayerSelectModeGameObjectEnableSetter : MonoBehaviour
{
	[SerializeField]
	private GameObject refTarget;

	[SerializeField]
	private bool isActive;

	void OnPlayerSelectMode()
	{
		refTarget.SetActive( isActive );
	}
}
