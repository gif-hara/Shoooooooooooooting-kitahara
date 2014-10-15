/*===========================================================================*/
/*
*     * FileName    : CommandDecideEventGameObjectEnableSetter.cs
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
public class CommandDecideEventGameObjectEnableSetter : MonoBehaviour
{
	[SerializeField]
	private GameObject refTarget;

	[SerializeField]
	private bool isActive;

	void OnDecideEvent()
	{
		refTarget.SetActive( isActive );
	}
}
