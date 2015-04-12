/*===========================================================================*/
/*
*     * FileName    : CollisionManager.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
#define OnDrawGizmos
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class CollisionManager : GameMonoBehaviour
{
	public int enemyShotCollisionTileX;
	
	public int enemyShotCollisionTileY;
	
	private List<A_Collider> enemyColliderList = new List<A_Collider>();
	
	private List<EnemyShotCollider> enemyShotColliderList = new List<EnemyShotCollider>();
	
	private List<A_Collider> playerColliderList = new List<A_Collider>();
	
	private List<A_Collider> playerShotColliderList = new List<A_Collider>();
	
	private List<A_Collider> barrierColliderList = new List<A_Collider>();

	private List<A_Collider> itemColliderList = new List<A_Collider>();
	
	private List<List<List<A_Collider>>> enemyShotVarianceList = null;
	
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

		if( PauseManager.Instance.IsPause )	return;
		
		int benchMarkId = ScriptProfiler.Begin( this );
		CollisionEnemyAndPlayer();
		CollisionEnemyAndPlayerShot();
		CollisionEnemyShotAndPlayer();
		CollisionEnemyShotAndBarrier();
		CollisionPlayerAndItem();
		ScriptProfiler.End( this, benchMarkId );
	}
	
#if OnDrawGizmos
	void OnDrawGizmosSelected()
	{
		// Xの敵弾分散線の描画.
		float intervalX = (GameDefine.Screen.width / enemyShotCollisionTileX) * 2;
		for( int i=0; i<=enemyShotCollisionTileX; i++ )
		{
			float currentX = -GameDefine.Screen.width + (intervalX * i);
			Gizmos.DrawLine( new Vector3( currentX, GameDefine.Screen.y, 0.0f ), new Vector3( currentX, GameDefine.Screen.height, 0.0f ) );
		}
		
		// Yの敵弾分散線の描画.
		float intervalY = (GameDefine.Screen.y / enemyShotCollisionTileY) * 2;
		for( int i=0; i<=enemyShotCollisionTileY; i++ )
		{
			float currentY = -GameDefine.Screen.y + (intervalY * i);
			Gizmos.DrawLine( new Vector3( GameDefine.Screen.x, currentY, 0.0f ), new Vector3( GameDefine.Screen.width, currentY, 0.0f ) );
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
	public void AddEnemyShotCollider( EnemyShotCollider col )
	{
		enemyShotColliderList.Add( col );
//		var id = GetEnemyShotVarianceId( col.cachedTransform );
//		enemyShotVarianceList[(int)id.y][(int)id.x].Add( col );
//		Debug.Log( "Init id = " + id );
		
//		return id;
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
	/// <summary>
	/// アイテムコライダーの追加.
	/// </summary>
	/// <param name="col">Col.</param>
	public void AddItemCollider( A_Collider col )
	{
		itemColliderList.Add( col );
	}

	/// <summary>
	/// 敵弾を全て死亡させる.
	/// </summary>
	public void AllDestroyEnemyShot()
	{
		StartCoroutine( AllDestroyEnemyShotCoroutine() );
	}
	private IEnumerator AllDestroyEnemyShotCoroutine()
	{
		yield return new WaitForEndOfFrame();

		for( int i=0,imax=this.enemyShotColliderList.Count; i<imax; i++ )
		{
			var e = this.enemyShotColliderList[i];
			if( !e.refEnemyShot.gameObject.activeInHierarchy )
			{
				continue;
			}

			e.refEnemyShot.Explosion();
		}
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
		CollisionXAndY( enemyShotColliderList, PlayerColliderListNonInvincible );
//		enemyShotColliderList.RemoveAll( e => e == null );
//		var id = GetEnemyShotVarianceId( ReferenceManager.Player.cachedTransform );
//		var playerList = PlayerColliderListNonInvincible;
//		List<A_Collider> enemyShotList = new List<A_Collider>();
//
//		for( int y = (int)id.y - 1; y<=(int)id.y + 1; y++ )
//		{
//			if( y < 0 || y >= enemyShotCollisionTileY )	continue;
//			for( int x = (int)id.x - 1; x<=(int)id.x + 1; x++ )
//			{
//				if( x < 0 || x >= enemyShotCollisionTileX )	continue;
//				enemyShotList.AddRange( enemyShotVarianceList[y][x] );
//			}
//		}
//		
//		enemyShotList.RemoveAll( (obj) => obj == null );
//		
//		for( int i=0,imax=playerList.Count; i<imax; i++ )
//		{
//			for( int j=0,jmax=enemyShotList.Count; j<jmax; j++ )
//			{
//				if( !playerList[i].enabled || !enemyShotList[j].enabled )	continue;
//				
//				if( IsCollision( playerList[i], enemyShotList[j] ) )
//				{
//					playerList[i].OnCollision( enemyShotList[j] );
//					enemyShotList[j].OnCollision( playerList[i] );
//				}
//			}
//		}
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
	/// プレイヤーとアイテムの衝突処理.
	/// </summary>
	private void CollisionPlayerAndItem()
	{
		CollisionXAndY( playerColliderList, itemColliderList );
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
	private void CollisionXAndY<X, Y>( List<X> xList, List<Y> yList ) where X : A_Collider where Y : A_Collider
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
		var screen = GameDefine.Screen;
//		Debug.Log( "0pos = " + pos );
		pos.x = pos.x > screen.width ? screen.width : pos.x;
		pos.x = pos.x < screen.x ? screen.x : pos.x;
		pos.y = pos.y > screen.y ? screen.y : pos.y;
		pos.y = pos.y < screen.height ? screen.height : pos.y;
//		Debug.Log( "1pos = " + pos );
		pos.x += screen.width;
		pos.y -= screen.y;
//		Debug.Log( "2pos = " + pos );
		float varianceX = GameDefine.Screen.width / enemyShotCollisionTileX;
		float varianceY = GameDefine.Screen.y / enemyShotCollisionTileY;
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
