/*===========================================================================*/
/*
*     * FileName    : EnemyShotTriggerOnFire.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyShotTriggerOnFire : EnemyShotCreateComponentSeparate
{
	public List<EnemyShotCreator> refCreator;
	
	protected override void TuningFromSet ()
	{
		if( ((owner.TotalShotCount + 1) % separate) == 0 )
		{
			refCreator.ForEach( (obj) =>
			{
				obj.ForceFire();
			});
		}
	}
	
	protected override void TuningFromAdd ()
	{
		TuningFromSet();
	}
}
