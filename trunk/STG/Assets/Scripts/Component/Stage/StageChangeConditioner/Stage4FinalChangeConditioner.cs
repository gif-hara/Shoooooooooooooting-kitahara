/*===========================================================================*/
/*
*     * FileName    : Stage4MiddleChangeConditioner.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// .
/// </summary>
public class Stage4FinalChangeConditioner : A_StageChangeConditioner
{
	public override bool Condition()
	{
		if( GameStatusInterfacer.PlayStyle == GameDefine.PlayStyleType.Practice )
		{
			return
					(int)GameStatusInterfacer.Difficulty >= (int)GameDefine.DifficultyType.Hard
					&& GameStatusInterfacer.MissCount <= 0;
		}

		return
				GameManager.GameLevel >= 95
				&& ReferenceManager.Instance.RefPlayerStatusManager.MissCount <= 1
				&& ReferenceManager.Instance.refGameManager.IsAllReverseStageClear;
	}
}
