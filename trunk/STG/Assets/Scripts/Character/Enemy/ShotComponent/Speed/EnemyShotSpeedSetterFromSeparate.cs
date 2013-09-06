/*===========================================================================*/
/*
*     * FileName    : EnemyShotSpeedSetterFromSeparate.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotSpeedSetterFromSeparate : EnemyShotCreateComponentSeparate
{
	protected override void TuningFromSet ()
	{
		owner.speed = element.Evalute( Current );
	}
	protected override void TuningFromAdd ()
	{
		owner.speed += element.Evalute( Current );
	}
}
