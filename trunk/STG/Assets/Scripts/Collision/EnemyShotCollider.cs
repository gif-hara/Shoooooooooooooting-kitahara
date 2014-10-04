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


public class EnemyShotCollider : A_Collider
{
	public enum CollisionType : int
	{
		Graze,
		Miss,
	}
	public EnemyShot refEnemyShot;

	[SerializeField]
	private float grazeRadius;
	
	private Vector2 varianceId;

	private CollisionType collisionType = CollisionType.Graze;

	private float cachedRadius;

	private const float AddSpecialPoint = 1.1f;

	private const float AddGameLevelExperience = 2.5f;

	void OnDrawGizmos()
	{
		Gizmos.color = GizmosColor;
		Gizmos.DrawWireSphere( transform.position, radius );
		//Gizmos.DrawWireSphere( transform.position, grazeRadius );
	}

	public override void Start()
	{
		base.Start();
		this.cachedRadius = this.radius;
		this.radius = grazeRadius;
		varianceId = ReferenceManager.refCollisionManager.AddEnemyShotCollider( this );
	}
	public override void Update()
	{
		base.Update();
		varianceId = ReferenceManager.refCollisionManager.VarianceEnemyShotColliderList( this, varianceId );
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
		if( target.Type != EType.Player )
		{
			return;
		}

		if( collisionType == CollisionType.Graze )
		{
			this.radius = this.cachedRadius;
			collisionType = CollisionType.Miss;
			ReferenceManager.Instance.RefPlayerStatusManager.AddSpecialPoint( AddSpecialPoint );
			ReferenceManager.Instance.refGameManager.AddGameLevelExperience( AddGameLevelExperience );
		}
		else
		{
			target.Hit( this );
			refEnemyShot.Explosion();
		}
	}
}
