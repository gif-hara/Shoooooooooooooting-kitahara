/*===========================================================================*/
/*
*     * FileName    : RankingDataListDifficultyLabel.cs
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
public class RankingDataListDifficultyLabel : MonoBehaviour
{
	[SerializeField]
	private TextMesh content;

	void OnModifyRankingDataList( RankingDataList data )
	{
		content.text = data.DifficultyType.ToString();
	}
}
