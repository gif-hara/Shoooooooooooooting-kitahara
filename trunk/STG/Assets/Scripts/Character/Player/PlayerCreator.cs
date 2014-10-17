﻿/*===========================================================================*/
/*
*     * FileName    : PlayerCreator.cs
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
public class PlayerCreator : MonoBehaviour
{
	[SerializeField]
	private string createdMessage;

	[SerializeField]
	private List<Player> prefabPlayerList;

	private GameObject currentPlayer;

	void OnCreate( int id )
	{
		Destroy( currentPlayer );

		currentPlayer =  this.InstantiateAsChild( transform, prefabPlayerList[id].gameObject );
		currentPlayer.BroadcastMessage( createdMessage, SendMessageOptions.DontRequireReceiver );
	}
}
