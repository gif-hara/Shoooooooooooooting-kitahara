/*===========================================================================*/
/*
*     * FileName    : AutoPool.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class AutoPool : MonoBehaviour, I_Poolable
{
	public GameObject refTarget;
	
	public int delay;

	private int cachedDelay;

	// Update is called once per frame
	void Update()
	{
		if( PauseManager.Instance.IsPause )	return;
		
		if( delay <= 0 )
		{
			ObjectPool.Instance.ReleaseGameObject( refTarget );
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
	}
	
	public void OnReleaseByPool()
	{

	}
}
