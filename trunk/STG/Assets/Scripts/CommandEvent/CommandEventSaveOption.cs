/*===========================================================================*/
/*
*     * FileName    : CommandEventSaveOption.cs
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
public class CommandEventSaveOption : MonoBehaviour
{
	void OnCommandEvent()
	{
		SaveData.Settings.Instance.Apply( OptionData.Settings );
		SaveLoad.SaveSettings();
	}
}
