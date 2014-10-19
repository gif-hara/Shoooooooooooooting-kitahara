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
	/// ハイスコア.
	/// </summary>
	/// <value>The high score.</value>
	public ulong HighScore{ get{ return highScore; } }
	private ulong highScore = 10000;

	/// <summary>
	/// 獲得した星アイテムの数リスト.
	/// </summary>
	public List<int> EarnedStarItemList{ get{ return earnedStarItemList; } }
	private List<int> earnedStarItemList = null;

	public override void Awake ()
	{
		base.Awake ();
		InitializeGameStatus();
	}
	public override void Start ()
	{
		base.Start ();

		int capacity = 3;
		this.earnedStarItemList = new List<int>( capacity );
		for( int i=0; i<capacity; i++ )
		{
			this.earnedStarItemList.Add( 0 );
		}
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
		highScore = highScore < score ? score : highScore;
		ReferenceManager.refUILayer.BroadcastMessage( GameDefine.ModifiedScoreMessage, SendMessageOptions.DontRequireReceiver );
		ReferenceManager.RefPlayerStatusManager.Extend( score );
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
		value = (value + (ulong)GameManager.GrazeCount) * fixedGameLevel;
		AddScore( value );
	}
	public void InitStarItem()
	{
		for( int i=0,imax=this.earnedStarItemList.Count; i<imax; i++ )
		{
			this.earnedStarItemList[i] = 0;
		}
	}
	/// <summary>
	/// スターアイテムの獲得.
	/// </summary>
	public void EarnedStarItem( StarItemController starItem )
	{
		this.earnedStarItemList[starItem.Id]++;
		ulong value = (ulong)GameManager.GameLevel * (ulong)starItem.AddScoreRate;
		AddScore( value );
	}

	public void CreateStarItem( Vector3 position )
	{
		var starItem = InstantiateAsChild( ReferenceManager.refEffectLayer, PrefabStarItem );
		starItem.transform.position = position;
	}

	public void RegistGameStatus()
	{
		GameStatusInterfacer.Score = this.score;
		GameStatusInterfacer.HighScore = this.highScore;
	}

	private void InitializeGameStatus()
	{
		this.score = GameStatusInterfacer.Score;
		this.highScore = GameStatusInterfacer.HighScore;
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
