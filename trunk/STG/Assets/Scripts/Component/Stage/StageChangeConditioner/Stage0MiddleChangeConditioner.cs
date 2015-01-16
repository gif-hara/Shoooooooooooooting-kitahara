/*===========================================================================*/
/*
*     * FileName    : Stage0MiddleChangeConditioner.cs
*
*     * Description : ステージ０のステージ切り替え条件処理.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Stage0MiddleChangeConditioner : A_StageChangeConditioner
{
	[SerializeField]
	private int extensionNeedEnemyId;

	[SerializeField]
	private int extensionDestroyNum;

	public override bool Condition()
	{
		if( GameManager.DifficultyType == GameDefine.DifficultyType.Easy )
		{
			return false;
		}
		return GameManager.DestroyEnemyNumList[extensionNeedEnemyId] >= extensionDestroyNum;
	}
}
