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


public class EnemyShotIdSetterFromSeparate : EnemyShotCreateComponentSeparate
{
	protected override void TuningFromSet ()
	{
		owner.shotId = element.EvaluteFloorToInt( Current );
	}
	protected override void TuningFromAdd ()
	{
		owner.shotId += element.EvaluteFloorToInt( Current );
	}
}
