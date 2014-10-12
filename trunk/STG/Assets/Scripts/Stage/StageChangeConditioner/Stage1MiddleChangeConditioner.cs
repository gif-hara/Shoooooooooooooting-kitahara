/*===========================================================================*/
/*
*     * FileName    : Stage1ChangeConditioner.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Stage1MiddleChangeConditioner : A_StageChangeConditioner
{
	[SerializeField]
	private List<int> extensionNeedEnemyIdList;
	
	[SerializeField]
	private int extensionDestroyNum;

	public override bool Condition()
	{
		if( GameManager.DifficultyType == GameDefine.DifficultyType.Easy )
		{
			return false;
		}

		for( int i=0; i<extensionNeedEnemyIdList.Count; i++ )
		{
			if( GameManager.DestroyEnemyNumList[extensionNeedEnemyIdList[i]] < extensionDestroyNum )
			{
				return false;
			}
		}

		return true;
	}
}
