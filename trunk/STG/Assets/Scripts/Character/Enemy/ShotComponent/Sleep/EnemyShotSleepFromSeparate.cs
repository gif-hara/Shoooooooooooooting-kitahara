/*===========================================================================*/
/*
*     * FileName    : EnemyShotSleepFromSeparate.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotSleepFromSeparate : EnemyShotCreateComponentSeparate
{	
	protected override void TuningFromSet ()
	{
		sleep( () =>
		{
			owner.Sleep = element.EvaluteFloorToInt( Current );
		});
	}
	protected override void TuningFromAdd ()
	{
		sleep( () =>
		{
			owner.Sleep += element.EvaluteFloorToInt( Current );
		});
	}
	
	private void sleep( System.Action func )
	{
		if( ((owner.TotalShotCount + 1) % separate) == 0 )
		{
			func();
		}
	}
}
