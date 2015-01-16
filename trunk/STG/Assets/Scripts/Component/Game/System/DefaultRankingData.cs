/*===========================================================================*/
/*
*     * FileName    : DefaultRankingData.cs
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
public class DefaultRankingData : MonoBehaviour
{
	public AllRankingData AllRankingData{ get{ return allRankingData; } }
	[SerializeField]
	private AllRankingData allRankingData;

	[ContextMenu("Same Thing")]
	void SameThing()
	{
		allRankingData.SameThing( allRankingData.EasyData );
	}
}
