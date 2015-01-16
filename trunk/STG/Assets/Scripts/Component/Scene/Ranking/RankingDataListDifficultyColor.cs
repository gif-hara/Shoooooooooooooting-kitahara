/*===========================================================================*/
/*
*     * FileName    : RankingDataListDifficultyColor.cs
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
public class RankingDataListDifficultyColor : MonoBehaviour
{
	[SerializeField]
	private TextMesh content;

	[SerializeField]
	private List<Color> difficultyColor;
	
	void OnModifyRankingDataList( RankingDataList data )
	{
		content.color = GetColor( data.DifficultyType );
	}

	private Color GetColor( GameDefine.DifficultyType type )
	{
		return difficultyColor[(int)type];
	}
}
