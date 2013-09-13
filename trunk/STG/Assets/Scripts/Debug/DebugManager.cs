﻿/*===========================================================================*/
/*
*     * FileName    : DebugManager.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DebugManager : A_GUIElement
{
	/// <summary>
	/// リセットGUI参照.
	/// </summary>
	public ResetGUI refResetGUI;
	
	/// <summary>
	/// プレイヤー攻撃力を異常値にするか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is insanely force; otherwise, <c>false</c>.
	/// </value>
	public static bool IsInsanelyForce{ get{ return isInsanelyForce; } }
	private static bool isInsanelyForce = false;
	
	/// <summary>
	/// プレイヤーが無敵になるか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is invincible; otherwise, <c>false</c>.
	/// </value>
	public static bool IsInvincible{ get{ return isInvincible; } }
	private static bool isInvincible = false;
	
	/// <summary>
	/// プレイヤーのスペシャルポイントを無限にするか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is special point infinity; otherwise, <c>false</c>.
	/// </value>
	public static bool IsSpecialPointInfinity{ get{ return isSpecialPointInfinity; } }
	private static bool isSpecialPointInfinity = false;
	
	/// <summary>
	/// 残機が減るようになるか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is not life decrement; otherwise, <c>false</c>.
	/// </value>
	public static bool IsNotLifeDecrement{ get{ return isNotLifeDecrement; } }
	private static bool isNotLifeDecrement = false;
		
	public override void Update()
	{
		base.Update();
		// !~ ゲームレベルデバッグ.
		for( int i=0; i<10; i++ )
		{
			KeyPush( (KeyCode)((int)KeyCode.Alpha0 + i), () =>
			{
				GameManager.gameLevel = i*10;
			});
		}
		KeyPush( KeyCode.Backspace, () =>
		{
			GameManager.gameLevel = 100;
		});
		// ゲームレベルデバッグ ~!.
		
		// 攻撃力異常値デバッグ.
		KeyPush( KeyCode.Q, () =>
		{
			isInsanelyForce = !isInsanelyForce;
		});
		
		// 無敵デバッグ.
		KeyPush( KeyCode.W, () =>
		{
			isInvincible = !isInvincible;
		});
		
		// スペシャルポイント無限.
		KeyPush( KeyCode.E, () =>
		{
			isSpecialPointInfinity = !isSpecialPointInfinity;
		});
		
		// リセット.
		KeyPush( KeyCode.R, () =>
		{
			refResetGUI.Reset();
		});
		
		// 残機が減らないデバッグ.
		KeyPush( KeyCode.T, () =>
		{
			isNotLifeDecrement = !isNotLifeDecrement;
		});
	}
	
	public override void Draw()
	{
		Vertical( () =>
		{
			Label( string.Format( StringAsset.Get( "Format_DebugIsInsanelyForce" ), isInsanelyForce.ToString() ) );
			Label( string.Format( StringAsset.Get( "Format_DebugIsInvincible" ), isInvincible.ToString() ) );
			Label( string.Format( StringAsset.Get( "Format_DebugIsSpecialPointInfinity" ), isSpecialPointInfinity.ToString() ) );
			Label( StringAsset.Get( "Format_DebugReset" ) );
			Label( string.Format( StringAsset.Get( "Format_DebugIsNotDecrement" ), isNotLifeDecrement.ToString() ) );
		});
	}
	
	private void KeyPush( KeyCode keyCode, System.Action func )
	{
		if( Input.GetKeyDown( keyCode ) )
		{
			func();
		}
	}
}