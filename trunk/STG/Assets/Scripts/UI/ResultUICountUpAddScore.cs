/*===========================================================================*/
/*
*     * FileName    : ResultUICountUpAddScore.cs
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
public class ResultUICountUpAddScore : ResultUICountUp
{
	protected override void CountUpped (int addedValue)
	{
		base.CountUpped (addedValue);
		ReferenceManager.ScoreManager.AddScore( (ulong)addedValue );
	}
}
