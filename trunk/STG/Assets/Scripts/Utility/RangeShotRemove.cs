/*===========================================================================*/
/*
*     * FileName    : RangeShotRemove.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RangeShotRemove : A_DelayEvent
{
	/// <summary>
	/// 範囲.
	/// </summary>
	[SerializeField]
	private float radius;
	
	protected override void OnDelayEvent()
	{
		Remove( cachedTransform, radius );
	}
	/// <summary>
	/// 座標と半径から敵弾を削除する.
	/// 削除した数を返す.
	/// </summary>
	/// <returns>
	/// The remove.
	/// </returns>
	public static int Remove( Transform trans, float _range )
	{
		if( ReferenceManager.refEnemyShotLayer == null )	return 0;
		
		int result = 0;
		var shotList = ReferenceManager.refEnemyShotLayer.GetComponentsInChildren<EnemyShot>();
		foreach( var shot in shotList )
		{
			var sub = shot.cachedTransform.position - trans.position;
			float distance = sub.x * sub.x + sub.y * sub.y + sub.z * sub.z;
			float radius = 1.0f + _range * _range;
		
			if( distance < radius )
			{
				result++;
				shot.Explosion();
			}
		}
		
		return result;
	}
}
