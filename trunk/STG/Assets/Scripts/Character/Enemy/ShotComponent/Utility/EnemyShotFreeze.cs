/*===========================================================================*/
/*
*     * FileName    : EnemyShotFreeze.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotFreeze : EnemyShotCreateComponentSeparate
{
	public bool awakeFreeze;
	
	public int freezedInterval;
	
	void Start()
	{
		if( awakeFreeze )
		{
			owner.enabled = false;
		}
	}
	
	protected override void TuningFromSet ()
	{
		if( (owner.TotalShotCount + 1) % separate == 0 )
		{
			owner.enabled = false;
			owner.interval = freezedInterval;
		}
	}
	
	protected override void TuningFromAdd ()
	{
		TuningFromSet();
	}
}
