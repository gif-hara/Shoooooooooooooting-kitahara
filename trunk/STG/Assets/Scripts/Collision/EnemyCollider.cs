/*===========================================================================*/
/*
*     * FileName    : EnemyCollider.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyCollider : A_Collider
{
	public EnemyController refEnemy;
	
	public float damageRate = 1.0f;
	
	public List<EnemyControllerBase> refEnemyControllerBaseList;
	
	public override void Awake()
	{
		base.Awake();
		ReferenceManager.refCollisionManager.AddEnemyCollider( this );
	}
	
	public override void Update()
	{
		base.Update();
		UpdatePositionZ();
	}
	
	public override void OnCollision (A_Collider target)
	{
		if( target.Type == A_Collider.EType.PlayerShot )
		{
			var playerShot = target as PlayerShotCollider;
			if( playerShot.IsEnemyCollision )	return;
		}
		
		float damage = GetDamage( target );
		refEnemyControllerBaseList.ForEach( (obj) =>
		{
			obj.TakeDamage( damage );
		});
	}
	
	public override EType Type
	{
		get
		{
			return EType.Enemy;
		}
	}
	
	public bool IsDead
	{
		get
		{
			return refEnemy.IsDead;
		}
	}
	
	public float GetDamage( A_Collider target )
	{
		if( target.Type == A_Collider.EType.PlayerShot )
		{
			if( DebugManager.IsInsanelyForce )
			{
				return 99999;
			}
			return (target as PlayerShotCollider).power * damageRate;
		}
		
		return 0;
	}
}
