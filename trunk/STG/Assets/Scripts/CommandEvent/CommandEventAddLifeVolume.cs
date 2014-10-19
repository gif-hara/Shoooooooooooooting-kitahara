/*===========================================================================*/
/*
*     * FileName    : CommandEventAddLifeVolume.cs
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
public class CommandEventAddLifeVolume : MonoBehaviour
{
	[SerializeField]
	private int value;

	[SerializeField]
	private GameObject modifiedEventObject;

	void OnCommandEvent()
	{
		OptionData.Option.AddLifeVolume( value );
		modifiedEventObject.BroadcastMessage( "OnModifiedLife" );
	}
}
