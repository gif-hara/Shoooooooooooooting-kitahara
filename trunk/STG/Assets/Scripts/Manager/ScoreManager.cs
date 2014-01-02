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
	/// スコアアイテムプレハブリスト.
	/// </summary>
	[SerializeField]
	private List<GameObject> prefabScoreItemList;

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

	/// <summary>
	/// 倒した敵の数.
	/// </summary>
	private int destroyEnemyNum = 0;

	public override void Awake ()
	{
		earnedScoreItemList = new List<int>();
		prefabScoreItemList.ForEach( p =>
		{
			earnedScoreItemList.Add( 9999 );
		});
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
	/// スコアアイテムの獲得.
	/// </summary>
	/// <param name="id">Identifier.</param>
	public void EarnedScoreItem( int id )
	{
		EarnedScoreItem( id, 1 );
	}
	public void EarnedScoreItem( int id, int num )
	{
		earnedScoreItemList[id] += num;
		AddScore( (ulong)addScoreList[id] * (ulong)num ); 
	}
	public void DestroyEnemy( Vector3 destroyPosition )
	{
		destroyEnemyNum++;
		if( destroyEnemyNum % scoreItemCreateInterval == 0 )
		{
			var item = InstantiateAsChild( ReferenceManager.Instance.refEffectLayer, CreatableScoreItem );
			item.transform.localPosition = destroyPosition;
		}
	}

	private GameObject CreatableScoreItem
	{
		get
		{
			int id = (GameManager.GameLevel / 20);
			return prefabScoreItemList[id];
		}
	}
}
