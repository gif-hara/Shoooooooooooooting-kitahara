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
	public override void Start()
	{
		base.Start();
		maxInterval = interval;
	}
	
	// Update is called once per frame
	public override void Update()
	{
		base.Update();
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
