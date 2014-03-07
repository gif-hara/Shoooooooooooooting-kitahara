/*===========================================================================*/
/*
*     * FileName    :EnemyShotRandomRangeSetterFromGameLevel.cs
*
*     * Description : .
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
public class EnemyShotRandomRangeSetterFromGameLevel : EnemyShotCreateComponent
{
	protected override void TuningFromSet ()
	{
		float random = element.Evalute();
		owner.range = Random.Range( 0, random );
	}
	protected override void TuningFromAdd ()
	{
		float random = element.Evalute();
		owner.range += Random.Range( 0, random );
	}
}
