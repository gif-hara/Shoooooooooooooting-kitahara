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
using System.Collections.Generic;


public class EnemyShotFreeze : EnemyShotCreateComponentSeparate
{
	public bool awakeFreeze;
	
	public int freezedInterval;
	
	public override void Start()
	{
		base.Start();
		if( awakeFreeze )
		{
			owner.enabled = false;
		}
	}
	
	protected override void TuningFromSet ()
	{
		if( (owner.TotalShotCount + 1) % separate == 0 )
		{
			Freeze();
		}
	}
	
	protected override void TuningFromAdd ()
	{
		TuningFromSet();
	}

	private void Freeze()
	{
		owner.Freeze( freezedInterval );
	}
}
