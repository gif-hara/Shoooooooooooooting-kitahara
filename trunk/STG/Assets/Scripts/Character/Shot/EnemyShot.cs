/*===========================================================================*/
/*
*     * FileName    : EnemyShot.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShot : A_Shot
{
	public GameObject prefabExplosion;

	[SerializeField]
	private GameObject prefabStarItem;

	private bool isExplosion = false;
	
	public void Explosion()
	{
		if( isExplosion )	return;

		isExplosion = true;
		Destroy( gameObject );
		var explosion = InstantiateAsChild( ReferenceManager.refEffectLayer, prefabExplosion );
		explosion.transform.position = Trans.position;
	}

	public void ExplosionFromRangeShotRemove()
	{
		if( isExplosion )	return;

		Explosion();

		var pos = Trans.position;
		FrameRateUtility.StartCoroutine( 20, () =>
		{
			var starItem = InstantiateAsChild( ReferenceManager.refEffectLayer, prefabStarItem );
			starItem.transform.position = pos;
		});
	}

	protected override Transform Parent
	{
		get
		{
			return ReferenceManager.refEnemyShotLayer.transform;
		}
	}
}
