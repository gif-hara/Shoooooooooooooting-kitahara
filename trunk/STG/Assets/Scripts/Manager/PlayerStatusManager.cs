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
	/// SPポイント最大値.
	/// </summary>
	public const float MaxSpecialPoint = 100.0f;

	public override void Awake ()
	{
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
	}

	private void CreatePlayer()
	{
		InstantiateAsChild( ReferenceManager.refPlayerLayer, ReferenceManager.prefabPlayerList[playerId] );
	}
}
