﻿/*===========================================================================*/
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

	// Update is called once per frame
	void Update()
	{
		if( PauseManager.Instance.IsPause )	return;
		
		if( delay <= 0 )
		{
			Destroy( refTarget );
			enabled = false;
		}
		
		delay--;
	}

	[ContextMenu("Replace AutoPool")]
	void ReplaceAutoPool()
	{
		var autoPool = gameObject.AddComponent<AutoPool>();
		autoPool.refTarget = this.refTarget;
		autoPool.delay = this.delay;
		DestroyImmediate( this );
	}
}
