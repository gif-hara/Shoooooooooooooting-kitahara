/*===========================================================================*/
/*
*     * FileName    : EnemyShotIntervalSetterFromGameLevel.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotIntervalSetterFromGameLevel : EnemyShotCreateComponent
{
	protected override void TuningFromSet ()
	{
		owner.interval = element.EvaluteFloorToInt();
	}
	protected override void TuningFromAdd ()
	{
		owner.interval += element.EvaluteFloorToInt();
	}
}
