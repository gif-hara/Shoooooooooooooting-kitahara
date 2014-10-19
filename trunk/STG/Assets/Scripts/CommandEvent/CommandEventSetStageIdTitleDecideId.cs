/*===========================================================================*/
/*
*     * FileName    : CommandEventSetStageIdTitleDecideId.cs
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
public class CommandEventSetStageIdTitleDecideId : MonoBehaviour
{
	void OnCommandEvent()
	{
		GameStatusInterfacer.StageId = GameStatusInterfacer.TitleDecideStageId;
	}
}
