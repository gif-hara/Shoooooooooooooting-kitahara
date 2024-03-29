﻿/*===========================================================================*/
/*
*     * FileName    : BossRushDifficultyChangeConditioner.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BossRushDifficultyChangeConditioner : A_StageChangeConditioner
{
	public override bool Condition()
	{
		if( ReferenceManager.Instance.RefPlayerStatusManager.MissCount >= 1 )
		{
			return false;
		}

		return
			GameManager.DifficultyType == GameDefine.DifficultyType.Hard ||
			GameManager.DifficultyType == GameDefine.DifficultyType.Hell;
	}
}
