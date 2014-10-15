/*===========================================================================*/
/*
*     * FileName    : BossRushConditioner.cs
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
public class BossRushConditioner : MonoBehaviour
{
	void CatchCondition( ConditionHolder holder )
	{
		holder.IsSuccess = CanPlay;
	}
	private bool CanPlay
	{
		get
		{
			// 未実装.
			return false;
		}
	}
}
