/*===========================================================================*/
/*
*     * FileName    : EnemyShotRangeSetterFromGameLevel.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotRangeSetterFromGameLevel : EnemyShotCreateComponent
{
	protected override void TuningFromSet ()
	{
		owner.range = element.Evalute();
	}
	protected override void TuningFromAdd ()
	{
		owner.range += element.Evalute();
	}
}
