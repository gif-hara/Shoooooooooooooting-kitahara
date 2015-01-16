/*===========================================================================*/
/*
*     * FileName    : RankingRankLabel.cs
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
public class RankingRankLabel : MonoBehaviour
{
	[SerializeField]
	private TextMesh content;

	void OnModifyRankingData( RankingData data )
	{
		content.text = StringAsset.Format( "Rank", data.Rank, GetSuffix( data.Rank ) );
	}

	private string GetSuffix( int rank )
	{
		switch( rank )
		{
		case 1:
			return "st";
		case 2:
			return "nd";
		case 3:
			return "rd";
		default:
			return "th";
		}
	}
}
