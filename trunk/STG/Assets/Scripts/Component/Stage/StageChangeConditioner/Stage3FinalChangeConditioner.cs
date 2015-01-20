/*===========================================================================*/
/*
*     * FileName    : Stage3FinalChangeConditioner.cs
*
*     * Description : ステージ1のステージ切り替え条件処理.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Stage3FinalChangeConditioner : A_StageChangeConditioner
{
	public override bool Condition()
	{
		if( GameStatusInterfacer.PlayStyle == GameDefine.PlayStyleType.Practice )
		{
			return
					(int)GameStatusInterfacer.Difficulty >= (int)GameDefine.DifficultyType.Hard
					&& GameStatusInterfacer.MissCount <= 0;
		}

		Debug.Log( "IsAllReverseStageClear = " + GameManager.IsAllReverseStageClear );
		return GameManager.IsAllReverseStageClear;
	}
}
