/*===========================================================================*/
/*
*     * FileName    : CommandEventCancelOption.cs
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
public class CommandEventCancelOption : MonoBehaviour
{
	void OnCommandEvent()
	{
		SoundManager.Instance.SetSEVolume( SaveData.Settings.Instance.SEVolume );
		SoundManager.Instance.SetBGMVolume( SaveData.Settings.Instance.BGMVolume );
	}
}
