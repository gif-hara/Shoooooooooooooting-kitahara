/*===========================================================================*/
/*
*     * FileName    : CommandEventSetCanSaveReplay.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// .
/// </summary>
public class CommandEventSetCanSaveReplay : MonoBehaviour
{
	[SerializeField]
	private bool canSaveReplay;

	void OnCommandEvent()
	{
		GameStatusInterfacer.CanSaveReplay = canSaveReplay;
	}
}
