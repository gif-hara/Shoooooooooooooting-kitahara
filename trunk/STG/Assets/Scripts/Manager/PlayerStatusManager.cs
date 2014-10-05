/*===========================================================================*/
/*
*     * FileName    :PlayerStatusManager.cs
*
*     * Description : プレイヤーステータス管理者.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// プレイヤーステータス管理者.
/// </summary>
public class PlayerStatusManager : GameMonoBehaviour
{
	/// <summary>
	/// プレイヤーID.
	/// </summary>
	/// <value>The player identifier.</value>
	public int PlayerId{ set{ playerId = value; } get{ return playerId; } }
	[SerializeField]
	private int playerId;

	/// <summary>
	/// 残機数.
	/// </summary>
	/// <value>
	/// The life.
	/// </value>
	public int Life{ get{ return life; } }
	[SerializeField]
	private int life = 3;

	/// <summary>
	/// SPポイント.
	/// </summary>
	/// <value>The special point.</value>
	public float SpecialPoint{ get{ return specialPoint; } }
	[SerializeField]
	private float specialPoint;

	/// <summary>
	/// エクステンドするために必要なスコアリスト.
	/// </summary>
	[SerializeField]
	private List<string> extendScoreStringList;

	/// <summary>
	/// エクステンドするために必要なスコアリスト.
	/// ulongをシリアライズ出来ないので文字列からパース.
	/// </summary>
	private List<ulong> extendScoreList;

	/// <summary>
	/// プレイヤープレハブリスト.
	/// </summary>
	[SerializeField]
	private List<GameObject> prefabPlayerList;

	/// <summary>
	/// エクステンド回数.
	/// </summary>
	private int extendCount = 0;

	/// <summary>
	/// SPポイント最大値.
	/// </summary>
	public const float MaxSpecialPoint = 100.0f;

	public override void Awake ()
	{
		InitializeExtendScoreList();
		CreatePlayer();
	}

	public void AddSpecialPoint( float value )
	{
		// デバッグが有効なら常に最大値にする.
		if( DebugManager.IsSpecialPointInfinity )
		{
			specialPoint = MaxSpecialPoint;
			return;
		}

		specialPoint += value;
		specialPoint = specialPoint > MaxSpecialPoint ? MaxSpecialPoint : specialPoint;
	}

	public void UseSpecialMode( float needPoint )
	{
		specialPoint -= needPoint;
	}

	/// <summary>
	/// ミス処理.
	/// </summary>
	public void Miss()
	{
		if( DebugManager.IsNotLifeDecrement )	return;
		
		life--;
		life = life < 0 ? 0 : life;

		ReferenceManager.Instance.refUILayer.BroadcastMessage( GameDefine.MissEventMessage, SendMessageOptions.DontRequireReceiver );
	}

	public void Extend( ulong score )
	{
		if( extendCount >= extendScoreList.Count )
		{
			return;
		}

		if( score < extendScoreList[extendCount] )
		{
			return;
		}

		extendCount++;
		life++;
		ReferenceManager.Instance.refSoundManager.Play( "Extend" );
		ReferenceManager.Instance.refUILayer.BroadcastMessage( GameDefine.ExtendMessage );
	}

	public void DebugChange( int id )
	{
		playerId = id;
		CreatePlayer();
	}

	private void InitializeExtendScoreList()
	{
		extendScoreList = new List<ulong>( extendScoreStringList.Count );
		extendScoreStringList.ForEach( s =>
		{
			extendScoreList.Add( ulong.Parse( s ) );
		});
	}

	/// <summary>
	/// プレイヤーの生成.
	/// </summary>
	private void CreatePlayer()
	{
		if( ReferenceManager.Player != null )
		{
			Destroy( ReferenceManager.Player.gameObject );
		}
		InstantiateAsChild( ReferenceManager.refPlayerLayer, prefabPlayerList[playerId] );
	}
}
