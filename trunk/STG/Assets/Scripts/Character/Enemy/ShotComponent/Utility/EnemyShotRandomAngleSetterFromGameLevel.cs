/*===========================================================================*/
/*
*     * FileName    : EnemyShotRandomAngleSetterFromGameLevel.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotRandomAngleSetterFromGameLevel : EnemyShotCreateComponent
{
	public float origin;
	
	protected override void TuningFromSet ()
	{
		float random = element.Evalute();
		random = Random.Range( -random, random );
		random = origin + random;
		owner.transform.localRotation = Quaternion.AngleAxis( random, Vector3.forward );
	}
	protected override void TuningFromAdd ()
	{
		float random = element.Evalute();
		random = Random.Range( -random, random );
		owner.transform.localRotation *= Quaternion.AngleAxis( random, Vector3.forward );
	}
}
