/*===========================================================================*/
/*
*     * FileName    : MyInput.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

public class MyInput
{
	public static bool UpKey
	{
		get
		{
			return Input.GetButton( "Up" ) || Input.GetKey( KeyCode.UpArrow );
		}
	}
	public static bool UpKeyDown
	{
		get
		{
			return Input.GetButtonDown( "Up" ) || Input.GetKeyDown( KeyCode.UpArrow );
		}
	}
	public static bool DownKey
	{
		get
		{
			return Input.GetButton( "Down" ) || Input.GetKey( KeyCode.DownArrow );
		}
	}
	public static bool DownKeyDown
	{
		get
		{
			return Input.GetButtonDown( "Down" ) || Input.GetKeyDown( KeyCode.DownArrow );
		}
	}
	public static bool LeftKey
	{
		get
		{
			return Input.GetButton( "Left" ) || Input.GetKey( KeyCode.LeftArrow );
		}
	}
	public static bool LeftKeyDown
	{
		get
		{
			return Input.GetButtonDown( "Left" ) || Input.GetKeyDown( KeyCode.LeftArrow );
		}
	}
	public static bool RightKey
	{
		get
		{
			return Input.GetButton( "Right" ) || Input.GetKey( KeyCode.RightArrow );
		}
	}
	public static bool RightKeyDown
	{
		get
		{
			return Input.GetButtonDown( "Right" ) || Input.GetKeyDown( KeyCode.RightArrow );
		}
	}
	public static bool FireKey
	{
		get
		{
			return Input.GetButton( "Fire" );
		}
	}
	public static bool FireKeyDown
	{
		get
		{
			return Input.GetButtonDown( "Fire" );
		}
	}
	public static bool BombKey
	{
		get
		{
			return Input.GetButton( "Bomb" );
		}
	}
	public static bool BombKeyDown
	{
		get
		{
			return Input.GetButtonDown( "Bomb" );
		}
	}
	public static bool ShiftKey
	{
		get
		{
			return Input.GetButton( "Shift" );
		}
	}
	public static bool ShiftKeyDown
	{
		get
		{
			return Input.GetButtonDown( "Shift" );
		}
	}
	public static bool PauseKeyDown
	{
		get
		{
			return Input.GetButtonDown( "Pause" );
		}
	}
}
