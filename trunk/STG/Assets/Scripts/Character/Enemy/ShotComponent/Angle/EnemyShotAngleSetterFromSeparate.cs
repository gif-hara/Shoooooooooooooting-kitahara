/*===========================================================================*/
/*
*     * FileName    : EnemyShotAngleSetterFromSeparate.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotAngleSetterFromSeparate : EnemyShotCreateComponentSeparate
{
	protected override void TuningFromSet ()
	{
		owner.transform.localRotation = Quaternion.AngleAxis( element.Evalute( Current ), Vector3.forward );
	}
	protected override void TuningFromAdd ()
	{
		owner.transform.localRotation *= Quaternion.AngleAxis( element.Evalute( Current ), Vector3.forward );
	}
}
