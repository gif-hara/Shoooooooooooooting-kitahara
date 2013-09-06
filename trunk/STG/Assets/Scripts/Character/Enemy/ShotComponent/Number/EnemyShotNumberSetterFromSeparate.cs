/*===========================================================================*/
/*
*     * FileName    : EnemyShotNumberSetterFromSeparate.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotNumberSetterFromSeparate : EnemyShotCreateComponentSeparate
{
	protected override void TuningFromSet ()
	{
		owner.number = element.EvaluteFloorToInt( Current );
	}
	protected override void TuningFromAdd ()
	{
		owner.number += element.EvaluteFloorToInt( Current );
	}
}
