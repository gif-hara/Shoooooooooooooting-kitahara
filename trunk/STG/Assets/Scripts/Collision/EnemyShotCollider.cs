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
	
	private Vector2 varianceId;
	
	public override void Start()
	{
		base.Start();
		varianceId = ReferenceManager.refCollisionManager.AddEnemyShotCollider( this );
	}
	public override void Update()
	{
		base.Update();
		varianceId = ReferenceManager.refCollisionManager.VarianceEnemyShotColliderList( this, varianceId );
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
