/*===========================================================================*/
/*
*     * FileName    : Stage2MiddleChangeConditioner.cs
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
public class Stage2MiddleChangeConditioner : A_StageChangeConditioner
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
