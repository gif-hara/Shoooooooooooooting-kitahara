/*===========================================================================*/
/*
*     * FileName    : CommandEventSetStageIdCurrentStageId.cs
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
public class CommandEventSetStageIdCurrentStageId : MonoBehaviour
{
	void OnCommandEvent()
	{
		GameStatusInterfacer.StageId = ReferenceManager.Instance.refStageManager.StageId;
	}
}
