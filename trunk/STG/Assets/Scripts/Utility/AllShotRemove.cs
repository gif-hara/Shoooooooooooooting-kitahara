/*===========================================================================*/
/*
*     * FileName    : AllShotRemove.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AllShotRemove : A_DelayEvent
{
	protected override void OnDelayEvent()
	{
		if( ReferenceManager.refEnemyShotLayer == null )	return;
		
		var shotList = ReferenceManager.refEnemyShotLayer.GetComponentsInChildren<EnemyShot>();
		foreach( var shot in shotList )
		{
			shot.Explosion();
		}
	}
}
