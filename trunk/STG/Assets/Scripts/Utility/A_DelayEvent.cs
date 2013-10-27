/*===========================================================================*/
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
	
	// Update is called once per frame
	public override void Update()
	{
		if( delay <= 0 )
		{
			OnDelayEvent();
			enabled = false;
		}
		
		delay--;
	}
	
	/// <summary>
	/// ディレイアクション.
	/// </summary>
	protected abstract void OnDelayEvent();
}
