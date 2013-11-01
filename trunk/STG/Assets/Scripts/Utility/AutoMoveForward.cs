/*===========================================================================*/
/*
*     * FileName    : AutoMoveForward.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AutoMoveForward : GameMonoBehaviour
{
	public float speed;
		
	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		cachedTransform.localPosition += cachedTransform.up * speed;
	}
	
//	void OnDrawGizmos()
//	{
//		Gizmos.color = Color.red;
//		Gizmos.DrawLine( cachedTransform.position, cachedTransform.position + ( velocity * 9999.0f ) );
//	}
}
