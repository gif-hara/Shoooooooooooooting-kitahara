/*===========================================================================*/
/*
*     * FileName    : EnemyShotLookAtFromSeparate.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotLookAtFromSeparate : EnemyShotCreateComponentSeparate
{
	protected override void TuningFromSet ()
	{
		lookAt();
	}
	protected override void TuningFromAdd ()
	{
		lookAt();
	}
	
	private void lookAt()
	{
		if( (owner.TotalShotCount % separate) == 0 )
		{
			var target = ReferenceManager.refPlayer.Trans.position - transform.position;
			target.z = 0.0f;
			transform.rotation = Quaternion.LookRotation( target, Vector3.back );
			transform.rotation *= Quaternion.AngleAxis( 90.0f, Vector3.right );
		}
	}
}
