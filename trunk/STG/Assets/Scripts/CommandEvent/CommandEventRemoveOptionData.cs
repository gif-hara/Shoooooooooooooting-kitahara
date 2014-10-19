/*===========================================================================*/
/*
*     * FileName    : CommandEventRemoveOptionData.cs
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
public class CommandEventRemoveOptionData : MonoBehaviour
{
	void OnCommandEvent()
	{
		OptionData.Remove();
	}
}
