/*===========================================================================*/
/*
*     * FileName    : PlaySEInterval.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlaySEInterval : GameMonoBehaviour
{
	public string label;
	
	public int interval;
	
	private int maxInterval;
	
	// Use this for initialization
	void Start()
	{
		maxInterval = interval;
	}
	
	// Update is called once per frame
	void Update()
	{
		if( interval <= 0 )
		{
			ReferenceManager.refSoundManager.Play( label );
			interval = maxInterval;
		}
		else
		{
			interval--;
		}
	}
}
