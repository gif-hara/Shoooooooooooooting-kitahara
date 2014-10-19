/*===========================================================================*/
/*
*     * FileName    : CommandEventAddSEVolume.cs
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
public class CommandEventAddSEVolume : MonoBehaviour
{
	[SerializeField]
	private float value;

	[SerializeField]
	private GameObject modifiedEventObject;

	void OnCommandEvent()
	{
		OptionData.Option.AddSEVolume( value );
		modifiedEventObject.BroadcastMessage( "OnModifiedSEVolume" );
		SoundManager.Instance.SetSEVolume( OptionData.Option.SEVolume );
	}
}
