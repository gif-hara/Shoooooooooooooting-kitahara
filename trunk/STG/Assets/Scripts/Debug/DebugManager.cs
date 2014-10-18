/*===========================================================================*/
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
using System.Text;


public class DebugManager : A_GUIElement
{
	/// <summary>
	/// リセットGUI参照.
	/// </summary>
	public ResetGUI refResetGUI;
	
	/// <summary>
	/// ストップウォッチGUI参照.
	/// </summary>
	public StopWatchGUI refStopWatchGUI;

	/// <summary>
	/// プレイヤー管理者参照.
	/// </summary>
	[SerializeField]
	private PlayerStatusManager refPlayerStatusManager;
	
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
		
	public override void LateUpdate()
	{
		base.LateUpdate();
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
		
		// ストップウォッチトグル.
		KeyPush( KeyCode.Y, () =>
		{
			refStopWatchGUI.Toggle();
		});
		
		// ストップウォッチリセット.
		KeyPush( KeyCode.U, () =>
		        {
			refStopWatchGUI.Reset();
		});

		// 敵弾削除.
		KeyPush( KeyCode.I, () => ReferenceManager.refCollisionManager.AllDestroyEnemyShot() );

		// 裏ステージ全クリア.
		KeyPush( KeyCode.O, () =>
		        {
			GameManager.DebugReverseStageClear();
		});

		// リプレイデータの保存.
		KeyPush( KeyCode.P, () =>
		        {
			ReferenceManager.Instance.ReplayDataRecorder.Save( 0 );
		});

		KeyPush( KeyCode.A, () => refPlayerStatusManager.DebugChange( 0 ) );
		KeyPush( KeyCode.S, () => refPlayerStatusManager.DebugChange( 1 ) );
		KeyPush( KeyCode.D, () => refPlayerStatusManager.DebugChange( 2 ) );
		KeyPush( KeyCode.F, () => refPlayerStatusManager.DebugChange( 3 ) );
		KeyPush( KeyCode.G, () => refPlayerStatusManager.DebugChange( 4 ) );
		KeyPush( KeyCode.H, () => refPlayerStatusManager.DebugChange( 5 ) );
	}
	
	public override void Draw()
	{
		var builder = new StringBuilder();
		builder.AppendFormat( StringAsset.Get( "Format_DebugGameLevel" ) );
		builder.AppendLine();
		builder.AppendFormat( StringAsset.Get( "Format_DebugIsInsanelyForce" ), isInsanelyForce.ToString() );
		builder.AppendLine();
		builder.AppendFormat( StringAsset.Get( "Format_DebugIsInvincible" ), isInvincible.ToString() );
		builder.AppendLine();
		builder.AppendFormat( StringAsset.Get( "Format_DebugIsSpecialPointInfinity" ), isSpecialPointInfinity.ToString() );
		builder.AppendLine();
		builder.Append( StringAsset.Get( "Format_DebugReset" ) );
		builder.AppendLine();
		builder.AppendFormat( StringAsset.Get( "Format_DebugIsNotDecrement" ), isNotLifeDecrement.ToString() );
		builder.AppendLine();
		builder.Append( StringAsset.Get( "Format_DebugStopWatchToggle" ) );
		builder.AppendLine();
		builder.Append( StringAsset.Get( "Format_DebugStopWatchReset" ) );
		builder.AppendLine();
		builder.Append( StringAsset.Get( "Format_DebugAllDestroyEnemyShot" ) );
		builder.AppendLine();
		builder.Append( StringAsset.Get( "Format_DebugReverseStageClear" ) );
		builder.AppendLine();
		builder.Append( StringAsset.Get( "Format_DebugPlayerCreate" ) );
		Label( builder.ToString() );
	}
	
	private void KeyPush( KeyCode keyCode, System.Action func )
	{
		if( Input.GetKeyDown( keyCode ) )
		{
			func();
		}
	}
}
