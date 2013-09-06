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


public class AutoMove : MonoBehaviour
{
	public float speed;
	
	public Vector3 velocity;
	
	private Transform trans;
	
	// Use this for initialization
	void Start()
	{
		trans = transform;
	}

	// Update is called once per frame
	void Update()
	{
		trans.localPosition += velocity * speed;
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine( trans.position, trans.position + ( velocity * 9999.0f ) );
	}
}
