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
		modifiedEventObject.BroadcastMessage( "OnModifiedWindowStyle" );
		SoundManager.Instance.SetBGMVolume( OptionData.Settings.BGMVolume );
		SoundManager.Instance.SetSEVolume( OptionData.Settings.SEVolume );
		Screen.fullScreen = OptionData.Settings.WindowStyle == GameDefine.WindowStyle.FullScreen;
	}
}
