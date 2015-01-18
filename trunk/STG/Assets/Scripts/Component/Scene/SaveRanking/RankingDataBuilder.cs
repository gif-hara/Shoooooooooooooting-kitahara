/*===========================================================================*/
/*
*     * FileName    : RankingDataBuilder.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// .
/// </summary>
public class RankingDataBuilder : MonoBehaviour
{
	[SerializeField]
	private RankingElementObserver refObserver;

	private RankingData data;

	private int rank = 0;

	// Use this for initialization
	void Start ()
	{
		rank = GameStatusInterfacer.Rank;
		data = new RankingData(
			rank + 1,
			GameStatusInterfacer.Score,
			GameStatusInterfacer.ClearedStageType,
			GameStatusInterfacer.PlayerId,
			""
			);
		refObserver.Content = data;
	}

	public void SetUserName( string name )
	{
		data.UserName = name;
		refObserver.Content = data;
	}

	public void Save()
	{
		SaveData.Ranking.Instance.DataList.Insert(
			GameStatusInterfacer.Difficulty,
			rank,
			data
			);
		SaveLoad.SaveRanking();
	}
}
