/*===========================================================================*/
/*
*     * FileName    : PlaySE.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlaySE : GameMonoBehaviour
{
	public string label;
	
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
			ReferenceManager.refSoundManager.Play( label );
			enabled = false;
		}
		
		delay--;
	}
}
