/*===========================================================================*/
/*
*     * FileName    : TweenShake.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TweenShake : MonoBehaviour
{
	public Vector3 initialPosition;
	
	public int rate = 0;
	
	public int duration = 0;
	
	private int maxDuration = 0;
	
	private Transform cachedTrans;
	
	// Use this for initialization
	void Start()
	{
		cachedTrans = transform;
		maxDuration = duration;
	}

	// Update is called once per frame
	void Update()
	{
		if( PauseManager.Instance.IsPause )	return;
		
		UpdateShake();
	}
	
	public static void Begin( GameObject go, Vector3 initialPos, int rate, int duration )
	{
		var instance = go.GetComponent<TweenShake>();
		if( instance == null )
		{
			instance = go.AddComponent<TweenShake>();
		}
		
		instance.enabled = true;
		instance.initialPosition = initialPos;
		instance.duration = duration;
		instance.rate = rate;
		instance.maxDuration = duration;
	}
	
	private void UpdateShake()
	{
		if( duration < 0 )
		{
			enabled = false;
			cachedTrans.position = initialPosition;
			return;
		}
		
		float velRate = rate * ((float)duration / maxDuration);
		var velocity = ( Random.insideUnitCircle * velRate );
		var pos = initialPosition + new Vector3( velocity.x, velocity.y, 0.0f );
		
		cachedTrans.position = pos;
		duration--;
	}
}
