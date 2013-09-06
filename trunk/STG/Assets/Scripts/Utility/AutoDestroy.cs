/*===========================================================================*/
/*
*     * FileName    : AutoDestroy.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AutoDestroy : MonoBehaviour
{
	public GameObject refTarget;
	
	public int delay;
	
	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		if( delay <= 0 )
		{
			Destroy( refTarget );
			enabled = false;
		}
		
		delay--;
	}
}
