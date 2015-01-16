/*===========================================================================*/
/*
*     * FileName    : RankingDataList.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
[System.Serializable]
public class RankingDataList
{
	public List<RankingData> Data
	{
		get
		{
			return data;
		}
	}
	[SerializeField]
	private List<RankingData> data;

	public GameDefine.DifficultyType DifficultyType
	{
		get
		{
			return difficultyType;
		}
	}
	[SerializeField]
	private GameDefine.DifficultyType difficultyType;

	public RankingDataList( RankingDataList other )
	{
		data = new List<RankingData>( other.data );
		//difficultyType = other.difficultyType;
	}
}
