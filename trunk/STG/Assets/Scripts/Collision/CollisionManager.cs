/*===========================================================================*/
/*
*     * FileName    : CollisionManager.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
//#define OnDrawGizmos
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CollisionManager : GameMonoBehaviour
{
	public int enemyShotCollisionTileX;
	
	public int enemyShotCollisionTileY;
	
	private List<A_Collider> enemyColliderList = new List<A_Collider>();
	
	private List<A_Collider> enemyShotColliderList = new List<A_Collider>();
	
	private List<A_Collider> playerColliderList = new List<A_Collider>();
	
	private List<A_Collider> playerShotColliderList = new List<A_Collider>();
	
	private List<A_Collider> barrierColliderList = new List<A_Collider>();
	
	private List<List<List<A_Collider>>> enemyShotVarianceList = null;
	
	private const float StageX = 350.0f;
	
	private const float StageY = 350.0f;
	
	public override void Awake()
	{
		base.Awake();
		enemyShotVarianceList = new List<List<List<A_Collider>>>();
		for( int y=0; y<enemyShotCollisionTileY; y++ )
		{
			enemyShotVarianceList.Add( new List<List<A_Collider>>() );
			for( int x=0; x<enemyShotCollisionTileX; x++ )
			{
				enemyShotVarianceList[y].Add( new List<A_Collider>() );
			}
		}
	}
	// Use this for initialization
	public override void Start()
	{
		base.Start();
	}

	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		int benchMarkId = ScriptProfiler.Begin( this );
		CollisionEnemyAndPlayer();
		CollisionEnemyAndPlayerShot();
		CollisionEnemyShotAndPlayer();
		CollisionEnemyShotAndBarrier();
		ScriptProfiler.End( this, benchMarkId );
	}
	
#if OnDrawGizmos
	void OnDrawGizmos()
	{
		// Xの敵弾分散線の描画.
		float intervalX = (StageX / enemyShotCollisionTileX) * 2;
		for( int i=0; i<=enemyShotCollisionTileX; i++ )
		{
			float currentX = -StageX + (intervalX * i);
			Gizmos.DrawLine( new Vector3( currentX, StageY, 0.0f ), new Vector3( currentX, -StageY, 0.0f ) );
		}
		
		// Yの敵弾分散線の描画.
		float intervalY = (StageY / enemyShotCollisionTileY) * 2;
		for( int i=0; i<=enemyShotCollisionTileY; i++ )
		{
			float currentY = -StageX + (intervalY * i);
			Gizmos.DrawLine( new Vector3( -StageX, currentY, 0.0f ), new Vector3( StageX, currentY, 0.0f ) );
		}
	}
#endif
	/// <summary>
	/// 敵コライダーの追加.
	/// </summary>
	/// <param name='col'>
	/// Col.
	/// </param>
	public void AddEnemyCollider( EnemyCollider col )
	{
		enemyColliderList.Add( col );
	}
	/// <summary>
	/// 敵弾コライダーの追加.
	/// </summary>
	/// <param name='col'>
	/// Col.
	/// </param>
	public Vector2 AddEnemyShotCollider( EnemyShotCollider col )
	{
		enemyShotColliderList.Add( col );
		var id = GetEnemyShotVarianceId( col.cachedTransform );
		enemyShotVarianceList[(int)id.y][(int)id.x].Add( col );
//		Debug.Log( "Init id = " + id );
		
		return id;
	}
	/// <summary>
	/// プレイヤーコライダーの追加.
	/// </summary>
	/// <param name='col'>
	/// Col.
	/// </param>
	public void AddPlayerCollider( PlayerCollider col )
	{
		playerColliderList.Add( col );
	}
	/// <summary>
	/// プレイヤー弾の追加.
	/// </summary>
	/// <param name='col'>
	/// Col.
	/// </param>
	public void AddPlayerShotCollider( PlayerShotCollider col )
	{
		playerShotColliderList.Add( col );
	}
	/// <summary>
	/// バリアコライダーの追加.
	/// </summary>
	/// <param name='col'>
	/// Col.
	/// </param>
	public void AddBarrierCollider( BarrierCollider col )
	{
		barrierColliderList.Add( col );
	}
	public Vector2 VarianceEnemyShotColliderList( A_Collider enemyShot, Vector2 id )
	{
		var currentId = GetEnemyShotVarianceId( enemyShot.cachedTransform );
		if( (int)currentId.x == (int)id.x && (int)currentId.y == (int)id.y )	return id;
		
		enemyShotVarianceList[(int)id.y][(int)id.x].Remove( enemyShot );
		enemyShotVarianceList[(int)currentId.y][(int)currentId.x].Add( enemyShot );
		
		return currentId;
	}
	/// <summary>
	/// 敵とプレイヤーの衝突処理.
	/// </summary>
	private void CollisionEnemyAndPlayer()
	{
		CollisionXAndY( PlayerColliderListNonInvincible, enemyColliderList );
	}
	/// <summary>
	/// 敵とプレイヤー弾の衝突処理.
	/// </summary>
	private void CollisionEnemyAndPlayerShot()
	{
		CollisionXAndY( enemyColliderList, playerShotColliderList );
	}
	/// <summary>
	/// 敵弾とプレイヤーの衝突処理.
	/// </summary>
	private void CollisionEnemyShotAndPlayer()
	{
		var id = GetEnemyShotVarianceId( ReferenceManager.refPlayer.cachedTransform );
		var xList = PlayerColliderListNonInvincible;
		List<A_Collider> yList = new List<A_Collider>();
		
		for( int y = (int)id.y - 1; y<=(int)id.y + 1; y++ )
		{
			if( y < 0 || y >= enemyShotCollisionTileY )	continue;
			for( int x = (int)id.x - 1; x<=(int)id.x + 1; x++ )
			{
				if( x < 0 || x >= enemyShotCollisionTileX )	continue;
				yList.AddRange( enemyShotVarianceList[y][x] );
			}
		}
		
		yList.RemoveAll( (obj) => obj == null );
		
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
	/// <summary>
	/// 敵弾とバリアの衝突処理.
	/// </summary>
	private void CollisionEnemyShotAndBarrier()
	{
		if( barrierColliderList.Count <= 0 )	return;
		
		CollisionXAndY( barrierColliderList, enemyShotColliderList );
	}
	/// <summary>
	/// XリストとYリストの衝突処理.
	/// </summary>
	/// <param name='xList'>
	/// X list.
	/// </param>
	/// <param name='yList'>
	/// Y list.
	/// </param>
	private void CollisionXAndY( List<A_Collider> xList, List<A_Collider> yList )
	{
		xList.RemoveAll( (obj) => obj == null );
		yList.RemoveAll( (obj) => obj == null );
		
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
	
	private Vector2 GetEnemyShotVarianceId( Transform trans )
	{
		var pos = trans.position;
//		Debug.Log( "0pos = " + pos );
		pos.x = pos.x > StageX ? StageX : pos.x;
		pos.x = pos.x < -StageX ? -StageX : pos.x;
		pos.y = pos.y > StageY ? StageY : pos.y;
		pos.y = pos.y < -StageY ? -StageY : pos.y;
//		Debug.Log( "1pos = " + pos );
		pos.x += StageX;
		pos.y -= StageY;
//		Debug.Log( "2pos = " + pos );
		float varianceX = StageX / enemyShotCollisionTileX;
		float varianceY = StageY / enemyShotCollisionTileY;
//		Debug.Log( "3pos = " + pos );
		
		int resultX = (int)(pos.x / varianceX) / 2;
		int resultY = (int)(-pos.y / varianceY) / 2;
		resultX = resultX < 0 ? 0 : resultX;
		resultX = resultX > enemyShotCollisionTileX - 1 ? enemyShotCollisionTileX - 1 : resultX;
		resultY = resultY < 0 ? 0 : resultY;
		resultY = resultY > enemyShotCollisionTileY - 1 ? enemyShotCollisionTileY - 1 : resultY;
		
		return new Vector2( resultX, resultY );
	}
}
