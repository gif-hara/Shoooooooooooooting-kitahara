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

	void OnChangeScene()
	{
		this.StopAllCoroutines();
	}

	public static void StartCoroutine( int frame, System.Action func, bool isSafetyReference = false )
	{
		FrameRateUtility.Instance._StartCoroutine( frame, func, false, isSafetyReference );
	}
	public static void StartCoroutineIgnorePause( int frame, System.Action func, bool isSafetyReference = false )
	{
		FrameRateUtility.Instance._StartCoroutine( frame, func, true, isSafetyReference );
	}

	private void _StartCoroutine( int frame, System.Action func, bool isPauseActive, bool isSafetyReference )
	{
		StartCoroutine( __StartCoroutine( frame, func, isPauseActive, isSafetyReference ) );
	}
	
	private IEnumerator __StartCoroutine( int frame, System.Action func, bool isPauseActive, bool isSafetyReference )
	{
		for( int i=0; i<frame; i++ )
		{
			yield return new WaitForEndOfFrame();
			if( !isPauseActive && PauseManager.Instance.IsPause )
			{
				i--;
			}
		}

		if( isSafetyReference )
		{
			if( func.Target.ToString() != "null" )
			{
				func();
			}
		}
		else
		{
			func();
		}
	}
}
