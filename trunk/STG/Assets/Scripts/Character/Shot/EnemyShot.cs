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
	
	public void Explosion()
	{
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
