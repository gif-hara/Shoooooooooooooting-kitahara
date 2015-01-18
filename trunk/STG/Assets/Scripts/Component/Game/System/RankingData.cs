/*===========================================================================*/
/*
*     * FileName    : RankingData.cs
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
public class RankingData
{
	public int Rank
	{
		get
		{
			return rank;
		}
	}
	[SerializeField]
	private int rank;

	public ulong Score
	{
		get
		{
			return ulong.Parse( scoreString );
		}
	}
	[SerializeField]
	private string scoreString;

	public GameDefine.StageType ClearedStageType
	{
		get
		{
			return clearedStageType;
		}
	}
	[SerializeField]
	private GameDefine.StageType clearedStageType;

	public int PlayerId
	{
		get
		{
			return playerId;
		}
	}
	[SerializeField]
	private int playerId;

	public string UserName
	{
		set
		{
			userName = value;
		}
		get
		{
			return userName;
		}
	}
	[SerializeField]
	private string userName;

	public RankingData( int rank, ulong score, GameDefine.StageType clearedStageType, int playerId, string userName )
	{
		this.rank = rank;
		this.scoreString = score.ToString();
		this.clearedStageType = clearedStageType;
		this.playerId = playerId;
		this.userName = userName;
	}
}
