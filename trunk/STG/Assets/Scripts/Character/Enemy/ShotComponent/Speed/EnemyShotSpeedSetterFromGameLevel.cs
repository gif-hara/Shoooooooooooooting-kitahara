/*===========================================================================*/
/*
*     * FileName    : EnemyShotSpeedSetterFromGameLevel.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotSpeedSetterFromGameLevel : EnemyShotCreateComponent
{
	protected override void TuningFromSet ()
	{
		owner.speed = element.Evalute();
	}
	protected override void TuningFromAdd ()
	{
		owner.speed += element.Evalute();
	}
}
