/*===========================================================================*/
/*
*     * FileName    : FrameRateUtility.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FrameRateUtility : A_Singleton<FrameRateUtility>
{
	public override void Awake()
	{
		base.Awake();
		Instance = this;
	}
	public static void StartCoroutine( int frame, System.Action func )
	{
		FrameRateUtility.Instance._StartCoroutine( frame, func );
	}
	public static void StartCoroutineIgnorePause( int frame, System.Action func )
	{
		FrameRateUtility.Instance._StartCoroutine( frame, func, true );
	}

	private void _StartCoroutine( int frame, System.Action func, bool isPauseActive = false )
	{
		StartCoroutine( __StartCoroutine( frame, func, isPauseActive ) );
	}
	
	private IEnumerator __StartCoroutine( int frame, System.Action func, bool isPauseActive = false )
	{
		for( int i=0; i<frame; i++ )
		{
			yield return new WaitForEndOfFrame();
			if( !isPauseActive && PauseManager.Instance.IsPause )
			{
				i--;
			}
		}

		func();
	}
}
