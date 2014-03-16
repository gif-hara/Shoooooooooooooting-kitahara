/*===========================================================================*/
/*
*     * FileName    :AllDestroyEnemyShotFromEnemyHitPointEvent.cs
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
public class AllDestroyEnemyShotFromEnemyHitPointEvent : EventActionableFromEnemyHitPoint
{
	public override void Action ()
	{
		ReferenceManager.refCollisionManager.AllDestroyEnemyShot();
	}
}
