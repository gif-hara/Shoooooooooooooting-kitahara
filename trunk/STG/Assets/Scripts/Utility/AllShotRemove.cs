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
		AllRemove();
	}
	/// <summary>
	/// 全ての敵弾を削除する.
	/// 削除した数を返す.
	/// </summary>
	/// <returns>
	/// The remove.
	/// </returns>
	public static int AllRemove()
	{
		if( ReferenceManager.refEnemyShotLayer == null )	return 0;
		
		int result = 0;
		var shotList = ReferenceManager.refEnemyShotLayer.GetComponentsInChildren<EnemyShot>();
		foreach( var shot in shotList )
		{
			result++;
			shot.Explosion();
		}
		
		return result;
	}
}
