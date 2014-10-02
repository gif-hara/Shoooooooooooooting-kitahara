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


public class Stage1ChangeConditioner : A_StageChangeConditioner
{
	[SerializeField]
	private List<int> extensionNeedEnemyIdList;
	
	[SerializeField]
	private int extensionDestroyNum;

	public override bool Condition()
	{
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
