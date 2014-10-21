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
		OptionData.Settings.AddSEVolume( value );
		modifiedEventObject.BroadcastMessage( "OnModifiedSEVolume" );
		SoundManager.Instance.SetSEVolume( OptionData.Settings.SEVolume );
	}
}
