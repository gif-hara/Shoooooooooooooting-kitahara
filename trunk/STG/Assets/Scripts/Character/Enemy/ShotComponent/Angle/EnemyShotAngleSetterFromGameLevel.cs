/*===========================================================================*/
/*
*     * FileName    : EnemyShotAngleSetterFromGameLevel.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotAngleSetterFromGameLevel : EnemyShotCreateComponent
{
	protected override void TuningFromSet ()
	{
		owner.transform.localRotation = Quaternion.AngleAxis( element.Evalute(), Vector3.forward );
	}
	
	protected override void TuningFromAdd ()
	{
		owner.transform.localRotation *= Quaternion.AngleAxis( element.Evalute(), Vector3.forward );
	}
}
