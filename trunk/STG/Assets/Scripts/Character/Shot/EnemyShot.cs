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

	private bool isExplosion = false;
	
	public void Explosion()
	{
		if( isExplosion )	return;

		isExplosion = true;
		Destroy( gameObject );
		var explosion = InstantiateAsChild( ReferenceManager.refEffectLayer, prefabExplosion );
		explosion.transform.position = Trans.position;
	}
	protected override Transform Parent
	{
		get
		{
			return ReferenceManager.refEnemyShotLayer.transform;
		}
	}
}
