/*===========================================================================*/
/*
*     * FileName    : EnemyShotIntervalSetterFromSeparate.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotIntervalSetterFromSeparate : EnemyShotCreateComponentSeparate
{
	protected override void TuningFromSet ()
	{
		owner.interval = element.EvaluteFloorToInt( Current );
	}
	protected override void TuningFromAdd ()
	{
		owner.interval += element.EvaluteFloorToInt( Current );
	}
}
