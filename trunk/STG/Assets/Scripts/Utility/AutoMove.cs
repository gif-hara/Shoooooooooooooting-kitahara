/*===========================================================================*/
/*
*     * FileName    : AutoMove.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class AutoMove : MonoBehaviourExtension
{
	public float speed;
	
	public Vector3 velocity;
	
	private Vector3 cachedVelocity = Vector2.zero;
	
	public override void Start()
	{
		base.Start();
		cachedVelocity = velocity * speed;
	}
		
	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		cachedTransform.localPosition += cachedVelocity;
	}
	
//	void OnDrawGizmos()
//	{
//		Gizmos.color = Color.red;
//		Gizmos.DrawLine( cachedTransform.position, cachedTransform.position + ( velocity * 9999.0f ) );
//	}
}
