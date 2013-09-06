/*===========================================================================*/
/*
*     * FileName    : CollisionManager.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CollisionManager : MonoBehaviour
{
	private List<A_Collider> enemyColliderList = new List<A_Collider>();
	
	private List<A_Collider> enemyShotColliderList = new List<A_Collider>();
	
	private List<A_Collider> playerColliderList = new List<A_Collider>();
	
	private List<A_Collider> playerShotColliderList = new List<A_Collider>();
	
	private List<A_Collider> barrierColliderList = new List<A_Collider>();
	
	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		int benchMarkId = ScriptProfiler.Begin( this );
		CollisionEnemyAndPlayer();
		CollisionEnemyAndPlayerShot();
		CollisionEnemyShotAndPlayer();
		CollisionEnemyShotAndBarrier();
		ScriptProfiler.End( this, benchMarkId );
	}
	
	public void AddEnemyCollider( EnemyCollider col )
	{
		enemyColliderList.Add( col );
	}
	
	public void AddEnemyShotCollider( EnemyShotCollider col )
	{
		enemyShotColliderList.Add( col );
	}
	
	public void AddPlayerCollider( PlayerCollider col )
	{
		playerColliderList.Add( col );
	}
	
	public void AddPlayerShotCollider( PlayerShotCollider col )
	{
		playerShotColliderList.Add( col );
	}
	
	public void AddBarrierCollider( BarrierCollider col )
	{
		barrierColliderList.Add( col );
	}
	
	private void CollisionEnemyAndPlayer()
	{
		CollisionXAndY( PlayerColliderListNonInvincible, enemyColliderList );
	}
	private void CollisionEnemyAndPlayerShot()
	{
		CollisionXAndY( enemyColliderList, playerShotColliderList );
	}
	private void CollisionEnemyShotAndPlayer()
	{
		CollisionXAndY( PlayerColliderListNonInvincible, enemyShotColliderList );
	}
	private void CollisionEnemyShotAndBarrier()
	{
		if( barrierColliderList.Count <= 0 )	return;
		
		CollisionXAndY( barrierColliderList, enemyShotColliderList );
	}
	
	private void CollisionXAndY( List<A_Collider> xList, List<A_Collider> yList )
	{
		Remove( xList );
		Remove( yList );
		
		for( int i=0,imax=xList.Count; i<imax; i++ )
		{
			for( int j=0,jmax=yList.Count; j<jmax; j++ )
			{
				if( !xList[i].enabled || !yList[j].enabled )	continue;
				
				if( IsCollision( xList[i], yList[j] ) )
				{
					xList[i].OnCollision( yList[j] );
					yList[j].OnCollision( xList[i] );
				}
			}
		}
		
	}
	
	private void Remove( List<A_Collider> list )
	{
		list.RemoveAll( (obj) => obj == null );
	}
	private bool IsCollision( A_Collider a, A_Collider b )
	{
		var sub = a.Trans.position - b.Trans.position;
		float distance = sub.x * sub.x + sub.y * sub.y + sub.z * sub.z;
		float radius = a.radius * a.radius + b.radius * b.radius;
		
		return distance < radius;
	}
	
	private List<A_Collider> PlayerColliderListNonInvincible
	{
		get
		{
			var result = new List<A_Collider>( playerColliderList );
			result.RemoveAll( (obj) =>
			{
				var playerCollider = obj as PlayerCollider;
				return playerCollider.IsInvinciblePlayer;
			});
			
			return result;
		}
	}
}
