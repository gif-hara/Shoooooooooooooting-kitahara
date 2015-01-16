/*===========================================================================*/
/*
*     * FileName    : PauseManager.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class PauseManager : A_Singleton<PauseManager>
{
	public bool IsPause{ private set; get; }

	public override void Awake()
	{
		base.Awake();
		Instance = this;
	}

	public void Pause()
	{
		IsPause = true;
		Time.timeScale = 0.0f;
		Debug.Log( "Pause" );
	}

	public void UnPause()
	{
		IsPause = false;
		Time.timeScale = 1.0f;
		Debug.Log( "UnPause" );
	}

	public void Toggle()
	{
		if( IsPause )
		{
			UnPause();
		}
		else
		{
			Pause();
		}
	}
}
