/*===========================================================================*/
/*
*     * FileName    : EnemyShotRangeSetterFromSeparate.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotRangeSetterFromSeparate : EnemyShotCreateComponentSeparate
{
	protected override void TuningFromSet ()
	{
		owner.range = element.Evalute( Current );
	}
	protected override void TuningFromAdd ()
	{
		owner.range += element.Evalute( Current );
	}
}
