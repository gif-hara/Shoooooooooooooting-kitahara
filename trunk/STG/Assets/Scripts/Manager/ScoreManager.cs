/*===========================================================================*/
/*
*     * FileName    : ScoreManager.cs
*
*     * Description : スコア管理者クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// スコア管理者クラス.
/// </summary>
public class ScoreManager : GameMonoBehaviour
{
	public int scoreItemCreateInterval;

	/// <summary>
	/// 加算されるスコアリスト.
	/// </summary>
	[SerializeField]
	private List<int> addScoreList;

	/// <summary>
	/// スコア.
	/// </summary>
	public ulong Score{ get{ return score; } }
	private ulong score = 0;

	/// <summary>
	/// 獲得したスコアアイテムの数リスト.
	/// </summary>
	public List<int> EarnedScoreItemList{ get{ return earnedScoreItemList; } }
	private List<int> earnedScoreItemList = null;

	public override void Awake ()
	{
	}

	/// <summary>
	/// スコアの加算.
	/// </summary>
	/// <param name='value'>
	/// Value.
	/// </param>
	public void AddScore( ulong value )
	{
		score += value;
	}
	/// <summary>
	/// ゲームレベルを倍率にしたスコアの加算処理.
	/// </summary>
	/// <param name='value'>
	/// Value.
	/// </param>
	public void AddScoreRateGameLevel( ulong value )
	{
		int gameLevel = GameManager.GameLevel;
		ulong fixedGameLevel = gameLevel <= 1 ? 1 : (ulong)gameLevel;
		value = value * fixedGameLevel;
		AddScore( value );
	}
	/// <summary>
	/// スターアイテムの獲得.
	/// </summary>
	public void EarnedStarItem()
	{
		ulong value = 1 + (ulong)GameManager.CollisionEnemyShot / 10;
		AddScore( value );
	}
}
