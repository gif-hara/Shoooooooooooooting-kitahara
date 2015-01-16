/*===========================================================================*/
/*
*     * FileName    : RankingListMove.cs
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
public class RankingListMove : MonoBehaviour
{
	[SerializeField]
	private Vector3 initialPosition;

	[SerializeField]
	private ObjectMoveAttach refAttach;
	
	void OnModifyRankingDataList( RankingDataList data )
	{
		transform.localPosition = initialPosition;
		refAttach.Attach();
	}
}
