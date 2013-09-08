/*===========================================================================*/
/*
*     * FileName    : ObjectMoveTween.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;


public class ObjectMoveTween : A_ObjectMove
{
	private Vector3 initialPosition;
	
	public override void Start()
	{
		base.Start();
		initialPosition = refTrans.position;
	}
	
	protected override void UpdateMove()
	{
		refTrans.position = Vector3.Lerp( initialPosition, data.targetPosition, data.curve0.Evaluate( Duration ) );
		currentDuration++;
		
		if( currentDuration > data.durationFrame )
		{
			isComplete = true;
			if( data.isDestroy )
			{
				Destroy( refTrans.gameObject );
			}
		}
	}
}
