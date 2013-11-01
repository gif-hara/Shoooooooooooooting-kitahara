﻿/*===========================================================================*/
/*
*     * FileName    : Bomb.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Bomb : A_SpecialModeContent
{
	/// <summary>
	/// 効果時間.
	/// </summary>
	[SerializeField]
	private int duration;
	
	/// <summary>
	/// プレイヤー参照.
	/// </summary>
	private Player player;
	
	/// <summary>
	/// 現在の効果時間.
	/// </summary>
	private int currentDuration = 0;
	
	// Use this for initialization
	public override void Awake()
	{
		base.Awake();
		player = ReferenceManager.refPlayer;
		player.SetInvincible( duration + 60 );
	}
	
	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		
		if( currentDuration >= duration )
		{
			Destroy( gameObject );
			player.EndSpecialMode();
		}
		
		currentDuration++;
	}
}
