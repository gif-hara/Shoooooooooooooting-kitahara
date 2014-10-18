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

	[SerializeField]
	private Transform refTarget;

	[SerializeField]
	private Transform refForward;

	public override void Start()
	{
		if( this.refTarget == null )
		{
			this.refTarget = transform;
		}
		if( this.refForward == null )
		{
			this.refForward = transform;
		}
	}
		
	// Update is called once per frame
	public override void Update()
	{
		base.Update();

		if( PauseManager.Instance.IsPause )	return;
		
		this.refTarget.localPosition += refForward.up * speed;
	}
	
//	void OnDrawGizmos()
//	{
//		Gizmos.color = Color.red;
//		Gizmos.DrawLine( cachedTransform.position, cachedTransform.position + ( velocity * 9999.0f ) );
//	}
}
