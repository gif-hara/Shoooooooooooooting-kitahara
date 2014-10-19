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
		SoundManager.Instance.SetSEVolume( SaveLoad.Data.option.SEVolume );
		SoundManager.Instance.SetBGMVolume( SaveLoad.Data.option.BGMVolume );
	}
}
