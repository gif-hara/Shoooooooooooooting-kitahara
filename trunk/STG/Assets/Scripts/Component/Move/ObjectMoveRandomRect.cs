﻿/*===========================================================================*/
/*
*     * FileName    : ObjectMoveRandomRect.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ObjectMoveRandomRect : A_ObjectMove
{
	private LookAtObject refLookAtObject = null;
	
	private Transform target = null;

	private int exceptionTimer = 0;

	private const int ExceptionTime = 120;
	
	protected override void InitMove()
	{
		base.InitMove();
		var targetObj = new GameObject( "[ObjectMoveRandomRect] Target" );
		target = targetObj.transform;
		
		refLookAtObject = LookAtObject.Begin( refTrans, target, 0.1f );
		SetTargetPosition();
	}
	
	protected override void UpdateMove()
	{
		if( Vector3.Distance( refLookAtObject.Trans.position, target.position ) <= 10.0f
		   || this.exceptionTimer > ExceptionTime )
		{
			SetTargetPosition();
		}
		if( data.durationFrame <= 0 )
		{
			isComplete = true;
			Destroy( target.gameObject );
		}
		
		data.durationFrame--;
		refTrans.position -= refLookAtObject.Trans.up * data.speed;
		this.exceptionTimer++;
	}

	protected override void Finish ()
	{
	}
	
	private void SetTargetPosition()
	{
		float x = Random.Range( data.rect.x, data.rect.width );
		float y = Random.Range( data.rect.y, data.rect.height );
		
		target.position = new Vector3( x, y, 0.0f );
		this.exceptionTimer = 0;
	}
}
