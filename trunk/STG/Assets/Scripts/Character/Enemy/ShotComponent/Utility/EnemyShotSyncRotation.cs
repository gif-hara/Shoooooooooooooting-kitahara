/*===========================================================================*/
/*
*     * FileName    : EnemyShotSyncRotation.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class EnemyShotSyncRotation : EnemyShotCreateComponentSeparate
{
	[SerializeField]
	private Transform refTarget;

	[SerializeField]
	private Vector3 offset;

	protected override void TuningFromSet ()
	{
		if( (owner.TotalShotCount + 1) % separate == 0 )
		{
			this.cachedTransform.rotation = refTarget.rotation;
			this.cachedTransform.rotation *= Quaternion.Euler( offset );
		}
	}
	
	protected override void TuningFromAdd ()
	{
		TuningFromSet();
	}
}
