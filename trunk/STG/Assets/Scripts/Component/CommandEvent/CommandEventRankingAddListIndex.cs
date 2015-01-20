/*===========================================================================*/
/*
*     * FileName    : CommandEventRankingAddListIndex.cs
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
public class CommandEventRankingAddListIndex : MonoBehaviour
{
	[SerializeField]
	private RankingDataListAutoChange refRankingDataListAutoChange;

	[SerializeField]
	private int value;

	void OnCommandEvent()
	{
		refRankingDataListAutoChange.AddListIndex( value );
	}
}
