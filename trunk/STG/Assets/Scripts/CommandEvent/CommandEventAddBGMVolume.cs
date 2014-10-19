/*===========================================================================*/
/*
*     * FileName    : CommandEventAddBGMVolume.cs
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
public class CommandEventAddBGMVolume : MonoBehaviour
{
	[SerializeField]
	private float value;

	[SerializeField]
	private GameObject modifiedEventObject;

	void OnCommandEvent()
	{
		OptionData.Option.AddBGMVolume( value );
		modifiedEventObject.BroadcastMessage( "OnModifiedBGMVolume" );
		SoundManager.Instance.SetBGMVolume( OptionData.Option.BGMVolume );
	}
}
