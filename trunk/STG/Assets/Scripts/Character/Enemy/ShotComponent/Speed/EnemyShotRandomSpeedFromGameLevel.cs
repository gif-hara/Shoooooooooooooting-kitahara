/*===========================================================================*/
/*
*     * FileName    : EnemyShotRandomSpeedFromGameLevel.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyShotRandomSpeedFromGameLevel : EnemyShotCreateComponent
{
	protected override void TuningFromSet ()
	{
		float random = element.Evalute();
		owner.speed = Random.Range( 0, random );
	}
	protected override void TuningFromAdd ()
	{
		float random = element.Evalute();
		owner.speed += Random.Range( 0, random );
	}
}
