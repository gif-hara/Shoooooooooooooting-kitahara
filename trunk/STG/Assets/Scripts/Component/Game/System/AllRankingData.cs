/*===========================================================================*/
/*
*     * FileName    : AllRankingData.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// EasyやNormalなどの全てを保持したランキングデータ.
/// </summary>
[System.Serializable]
public class AllRankingData
{
	public RankingDataList EasyData{ get{ return easyData; } }
	[SerializeField]
	private RankingDataList easyData;
	
	public RankingDataList NormalData{ get{ return normalData; } }
	[SerializeField]
	private RankingDataList normalData;
	
	public RankingDataList HardData{ get{ return hardData; } }
	[SerializeField]
	private RankingDataList hardData;
	
	public RankingDataList HellData{ get{ return hellData; } }
	[SerializeField]
	private RankingDataList hellData;
	
	public RankingDataList ExtraData{ get{ return extraData; } }
	[SerializeField]
	private RankingDataList extraData;

	public AllRankingData( AllRankingData other )
	{
		this.easyData = other.easyData;
		this.normalData = other.normalData;
		this.hardData = other.hardData;
		this.hellData = other.hellData;
		this.extraData = other.extraData;
	}

	public RankingDataList GetData( int index )
	{
		RankingDataList[] result =
		{
			easyData,
			normalData,
			hardData,
			hellData,
			extraData,
		};

		return result[index % result.Length];
	}

	public void SameThing( RankingDataList other )
	{
		easyData = new RankingDataList( other );
		normalData = new RankingDataList( other );
		hardData = new RankingDataList( other );
		hellData = new RankingDataList( other );
		extraData = new RankingDataList( other );
	}
}
