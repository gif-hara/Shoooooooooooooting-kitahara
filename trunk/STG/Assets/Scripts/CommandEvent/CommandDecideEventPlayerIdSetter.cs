/*===========================================================================*/
/*
*     * FileName    : CommandDecideEventPlayerIdSetter.cs
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
public class CommandDecideEventPlayerIdSetter : MonoBehaviour
{
	[SerializeField]
	private int playerId;

	void OnCommandEvent()
	{
		GameStatusInterfacer.PlayerId = playerId;
	}
}
