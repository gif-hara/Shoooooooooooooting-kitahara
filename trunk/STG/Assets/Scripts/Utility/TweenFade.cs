/*===========================================================================*/
/*
*     * FileName    : TweenFade.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TweenFade : A_DelayEvent
{
	/// <summary>
	/// 初期色.
	/// </summary>
	[SerializeField]
	private Color from = Color.white;
	
	/// <summary>
	/// 最終色.
	/// </summary>
	[SerializeField]
	private Color to = Color.white;
	
	/// <summary>
	/// フェード時間.
	/// </summary>
	[SerializeField]
	private int duration;

	protected override void OnDelayEvent()
	{
		FadeManager.Instance.Begin( from, to, duration );
	}
}
