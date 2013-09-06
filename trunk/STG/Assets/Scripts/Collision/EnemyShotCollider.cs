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
	public EnemyShot refEnemyShot;
	
	void Awake()
	{
		ReferenceManager.refCollisionManager.AddEnemyShotCollider( this );
	}
	public override void OnCollision (A_Collider target)
	{
		refEnemyShot.Explosion();
		
		if( target.Type == A_Collider.EType.Barrier )
		{
			ReferenceManager.GameManager.AddGameLevelExperienceFromEnemyShot();
		}
	}
	public override EType Type
	{
		get
		{
			return EType.EnemyShot;
		}
	}
}
