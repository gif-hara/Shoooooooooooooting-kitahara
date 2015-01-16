/*===========================================================================*/
/*
*     * FileName    : RankingScoreLabel.cs
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
public class RankingScoreLabel : MonoBehaviour
{
	[SerializeField]
	private TextMesh content;
	
	void OnModifyRankingData( RankingData data )
	{
		content.text = data.Score.ToString( "#,0" );
	}
}
