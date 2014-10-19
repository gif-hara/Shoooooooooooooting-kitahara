/*===========================================================================*/
/*
*     * FileName    : CommandEventSetDefaultOption.cs
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
public class CommandEventSetDefaultOption : MonoBehaviour
{
	[SerializeField]
	private GameObject modifiedEventObject;

	void OnCommandEvent()
	{
		OptionData.Default();
		modifiedEventObject.BroadcastMessage( "OnModifiedSEVolume" );
		modifiedEventObject.BroadcastMessage( "OnModifiedBGMVolume" );
		modifiedEventObject.BroadcastMessage( "OnModifiedLife" );
		SoundManager.Instance.SetBGMVolume( OptionData.Option.BGMVolume );
		SoundManager.Instance.SetSEVolume( OptionData.Option.SEVolume );
	}
}
