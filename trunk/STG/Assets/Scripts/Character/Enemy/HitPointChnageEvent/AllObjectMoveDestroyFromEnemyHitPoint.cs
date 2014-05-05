/*===========================================================================*/
/*
*     * FileName    :AllObjectMoveDestroyFromEnemyHitPoint.cs
*
*     * Description : .
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
public class AllObjectMoveDestroyFromEnemyHitPoint : EventActionableFromEnemyHitPoint
{
	[SerializeField]
	private GameObject refParent;

	public override void Action ()
	{
		ObjectMoveUtility.AllDetach( refParent );
	}
}
