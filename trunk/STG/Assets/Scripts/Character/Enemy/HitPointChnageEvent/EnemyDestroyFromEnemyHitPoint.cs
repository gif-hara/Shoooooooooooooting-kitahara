/*===========================================================================*/
/*
*     * FileName    :EnemyDestroyFromEnemyHitPoint.cs
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
public class EnemyDestroyFromEnemyHitPoint : EventActionableFromEnemyHitPoint
{
	[SerializeField]
	private int destroyEnemyId;

	public override void Action ()
	{
		ReferenceManager.Instance.refEnemyLayer.BroadcastMessage( GameDefine.EnemyDestroyOnHitPointChangeEventMessage, destroyEnemyId );
	}
}
