/*===========================================================================*/
/*
*     * FileName    : CameraShake.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CameraShake : GameMonoBehaviour
{
	[SerializeField]
	private int delay;
	
	[SerializeField]
	private int rate;
	
	[SerializeField]
	private int duration;
	
	// Update is called once per frame
	public override void Update()
	{
		if( delay <= 0 )
		{
			TweenShake.Begin( ReferenceManager.refCameraParent, ReferenceManager.refCameraParent.transform.localPosition, rate, duration );
			enabled = false;
		}
		
		delay--;
	}

	public static void Begin( GameObject go, int delay, int rate, int duration )
	{
		var instance = go.AddComponent<CameraShake>();
		instance.delay = delay;
		instance.rate = rate;
		instance.duration = duration;
	}
}
