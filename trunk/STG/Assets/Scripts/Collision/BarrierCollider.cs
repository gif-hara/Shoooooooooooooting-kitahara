/*===========================================================================*/
/*
*     * FileName    : BarrierCollider.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BarrierCollider : A_Collider
{
	public override void Awake()
	{
		base.Awake();
		ReferenceManager.refCollisionManager.AddBarrierCollider( this );
	}

	public override void OnCollision(A_Collider target)
	{
	}
	
	public override EType Type
	{
		get
		{
			return EType.Barrier;
		}
	}
}
