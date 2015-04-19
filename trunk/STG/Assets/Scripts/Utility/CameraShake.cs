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


public class CameraShake : GameMonoBehaviour, I_Poolable
{
	[SerializeField]
	private int delay;
	
	[SerializeField]
	private int rate;
	
	[SerializeField]
	private int duration;

	[SerializeField]
	private int cachedDelay;
	
	// Update is called once per frame
	public override void Update()
	{
		if( PauseManager.Instance.IsPause )	return;
		
		if( delay <= 0 )
		{
			TweenShake.Begin( ReferenceManager.refCameraParent, Vector3.zero, rate, duration );
			enabled = false;
		}
		
		delay--;
	}

	public void OnAwakeByPool( bool used )
	{
		if( !used )
		{
			this.cachedDelay = this.delay;
		}
		else
		{
			this.delay = this.cachedDelay;
		}

		this.enabled = true;
	}

	public void OnReleaseByPool()
	{

	}

	public static void Begin( GameObject go, int delay, int rate, int duration )
	{
		var instance = go.AddComponent<CameraShake>();
		instance.delay = delay;
		instance.rate = rate;
		instance.duration = duration;
	}
}
