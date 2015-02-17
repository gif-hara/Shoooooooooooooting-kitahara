/*===========================================================================*/
/*
*     * FileName    : ExtraStageChangeConditioner.cs
*
*     * Description : Extraステージ切り替え条件処理.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ExtraStageChangeConditioner : A_StageChangeConditioner
{
	public override bool Condition()
	{
		return ReferenceManager.Instance.RefPlayerStatusManager.MissCount == 0;
	}
}
