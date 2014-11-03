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
	public ulong Score{ private set; get; }

	public GameDefine.StageType ClearedStageType{ private set; get; }

	public int PlayerId{ private set; get; }

	public string UserName{ private set; get; }
}
