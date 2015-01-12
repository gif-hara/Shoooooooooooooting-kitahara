﻿/*===========================================================================*/
/*
*     * FileName    : A_DelayEvent.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class A_DelayEvent : GameMonoBehaviour
{
	/// <summary>
	/// ディレイ.
	/// </summary>
	[SerializeField]
	private int delay;

	[SerializeField]
	protected bool ignorePause;

	public override void Start ()
	{
		base.Start ();

		Execute();
	}
	// Update is called once per frame
	public override void Update()
	{
		Execute();

		delay--;
	}

	private void Execute()
	{
		if( !ignorePause && PauseManager.Instance.IsPause )	return;
		
		if( delay <= 0 )
		{
			OnDelayEvent();
			enabled = false;
		}
	}
	
	/// <summary>
	/// ディレイアクション.
	/// </summary>
	protected abstract void OnDelayEvent();
}
