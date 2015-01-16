/*===========================================================================*/
/*
*     * FileName    : RankingPlayerNameLabel.cs
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
public class RankingPlayerNameLabel : MonoBehaviour
{
	[SerializeField]
	private TextMesh content;

	void OnModifyRankingData( RankingData data )
	{
		content.text = GameDefine.playerNames[data.PlayerId];
	}
}
