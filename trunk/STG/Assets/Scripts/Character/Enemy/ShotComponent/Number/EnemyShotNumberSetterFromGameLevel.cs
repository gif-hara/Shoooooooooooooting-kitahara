/*===========================================================================*/
/*
*     * FileName    : EnemyShotNumberSetterFromGameLevel.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotNumberSetterFromGameLevel : EnemyShotCreateComponent
{
	protected override void TuningFromSet ()
	{
		owner.number = element.EvaluteFloorToInt();
	}
	protected override void TuningFromAdd ()
	{
		owner.number += element.EvaluteFloorToInt();
	}
}
