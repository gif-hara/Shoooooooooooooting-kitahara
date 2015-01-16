/*===========================================================================*/
/*
*     * FileName    : CommandEventResetRetryData.cs
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
public class CommandEventResetRetryData : MonoBehaviour
{
	void OnCommandEvent()
	{
		GameStatusInterfacer.ResetRetryData();
	}
}
