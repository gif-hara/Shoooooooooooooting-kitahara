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
	[System.Serializable]
	public class StarItemCreateCondition
	{
		public GameObject Prefab{ get{ return prefab; } }
		[SerializeField]
		private GameObject prefab;

		public int Min{ get{ return min; } }
		[SerializeField]
		private int min;

		public int Max{ get{ return max; } }
		[SerializeField]
		private int max;
	}
	/// <summary>
	/// 星アイテムプレハブリスト.
	/// </summary>
	[SerializeField]
	private List<StarItemCreateCondition> starItemConditionList;

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
	public void EarnedStarItem( StarItemController starItem )
	{
		ulong value = (ulong)GameManager.GameLevel * (ulong)starItem.AddScoreRate;
		AddScore( value );
	}

	public void CreateStarItem( Vector3 position )
	{
		var starItem = InstantiateAsChild( ReferenceManager.refEffectLayer, PrefabStarItem );
		starItem.transform.position = position;
	}

	private GameObject PrefabStarItem
	{
		get
		{
			int gameLevel = GameManager.GameLevel;
			for( int i=0,imax=this.starItemConditionList.Count; i<imax; i++ )
			{
				var s = this.starItemConditionList[i];
				if( gameLevel >= s.Min && gameLevel < s.Max )
				{
					return s.Prefab;
				}
			}

			return null;
		}
	}
}
