/*===========================================================================*/
/*
*     * FileName    : EnemyShotCollider.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotCollider : A_Collider, I_Poolable
{
	public enum CollisionType : int
	{
		Graze,
		Miss,
	}
	public EnemyShot refEnemyShot;

	[SerializeField]
	private float grazeRadius;

	private CollisionType collisionType = CollisionType.Graze;

	private float cachedRadius;

	void OnDrawGizmosSelected()
	{
		Gizmos.color = GizmosColor;
		Gizmos.DrawWireSphere( transform.position, radius );
	}

	public void OnAwakeByPool( bool used )
	{
		if( !used )
		{
			this.cachedRadius = this.radius;
		}
		ReferenceManager.Instance.refCollisionManager.AddEnemyShotCollider( this );
		this.radius = grazeRadius;
		this.collisionType = CollisionType.Graze;
		this.enabled = true;
	}

	public void OnReleaseByPool()
	{
		ReferenceManager.Instance.refCollisionManager.RemoveEnemyShotCollider( this );
		this.enabled = false;
	}

	public override void OnCollision (A_Collider target)
	{
		OnCollisionBarrier( target );
		OnCollisionPlayer( target );
	}
	public override EType Type
	{
		get
		{
			return EType.EnemyShot;
		}
	}

	private void OnCollisionBarrier( A_Collider target )
	{
		if( target.Type != A_Collider.EType.Barrier )
		{
			return;
		}
		
		ReferenceManager.GameManager.AddGameLevelExperienceFromEnemyShot();
		refEnemyShot.Explosion();
	}
	private void OnCollisionPlayer( A_Collider target )
	{
		if( this.radius <= 0.0f || target.Type != EType.Player )
		{
			return;
		}

		if( collisionType == CollisionType.Graze )
		{
			this.radius = this.cachedRadius;
			collisionType = CollisionType.Miss;

//			var sub = this.cachedTransform.position - target.cachedTransform.position;
//			float distance = sub.x * sub.x + sub.y * sub.y + sub.z * sub.z;
//			float radius = this.radius * this.radius + target.radius * target.radius;
//			
//			if( distance < radius )
//			{
//				this.InternalHit( target );
//			}

			ReferenceManager.RefPlayerStatusManager.Graze( Trans );
			ReferenceManager.refScoreManager.CreateStarItem( Trans.position );
			GameManager.AddGrazeCount();
		}
		else
		{
			this.InternalHit( target );
		}
	}

	private void InternalHit( A_Collider target )
	{
		target.Hit( this );
		refEnemyShot.Explosion();
	}
}
