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


public class EnemyShot : A_Shot, I_Poolable
{
	public GameObject prefabExplosion;

	public bool NotRemove{ get{ return notRemove; } }
	[SerializeField]
	private bool notRemove;
	
	private bool isExplosion = false;

	public void OnAwakeByPool( bool used )
	{
		this.isExplosion = false;
	}
	
	public void OnReleaseByPool()
	{
	}
	
	public void Explosion()
	{
		if( isExplosion )
		{
			return;
		}

		isExplosion = true;
		ObjectPool.Instance.ReleaseGameObject( gameObject );
		var explosion = ObjectPool.Instance.GetGameObject( prefabExplosion );
		explosion.transform.position = Trans.position;
	}

	public void ExplosionFromRangeShotRemove()
	{
		if( isExplosion )
		{
			return;
		}

		Explosion();

		var pos = Trans.position;
		FrameRateUtility.StartCoroutine( 20, () =>
		{
			ScoreManager.CreateStarItem( pos );
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
