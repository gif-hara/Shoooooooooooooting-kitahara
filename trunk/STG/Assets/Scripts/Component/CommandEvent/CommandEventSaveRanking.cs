/*===========================================================================*/
/*
*     * FileName    : CommandEventSaveRanking.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// .
/// </summary>
public class CommandEventSaveRanking : MonoBehaviour
{
	[SerializeField]
	private RankingDataBuilder refRankingDataBuilder;

	void OnCommandEvent()
	{
		refRankingDataBuilder.Save();
	}
}
