/*===========================================================================*/
/*
*     * FileName    : CommandEventPlayerCreator.cs
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
public class CommandEventPlayerCreator : MonoBehaviour
{
	[SerializeField]
	private PlayerCreator refPlayerCreator;

	[SerializeField]
	private int playerId;

	void OnCommandEvent()
	{
		refPlayerCreator.OnCreate( playerId );
	}
}
