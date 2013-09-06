/*===========================================================================*/
/*
*     * FileName    : AddPositionFromVelocity.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AddPositionFromVelocity : MonoBehaviour
{
	public Transform refTarget;
	
	public Vector3 velocity;
	
	public int delay;
	
	public int duration;
	
	public float speed;
	
	private int maxDuration;
	
	// Use this for initialization
	void Start()
	{
		maxDuration = duration;
		velocity = velocity.normalized;
	}
	
	// Update is called once per frame
	void Update()
	{
		if( delay > 0 )
		{
			delay--;
			return;
		}
		if( duration <= 0 )
		{
			enabled = false;
		}
		refTarget.position += velocity * ( speed * ((float)duration / maxDuration) );
		duration--;
	}
}
