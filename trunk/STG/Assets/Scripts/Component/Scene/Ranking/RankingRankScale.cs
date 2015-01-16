/*===========================================================================*/
/*
*     * FileName    : RankingRankScale.cs
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
public class RankingRankScale : MonoBehaviour
{
	[SerializeField]
	private Transform content;

	[SerializeField]
	private List<float> size;
	
	void OnModifyRankingData( RankingData data )
	{
		content.localScale = new Vector3( size[data.Rank - 1], size[data.Rank - 1], 1.0f );
	}
}
