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
	
	private void _StartCoroutine( int frame, System.Action func )
	{
		StartCoroutine( __StartCoroutine( frame, func ) );
	}
	
	private IEnumerator __StartCoroutine( int frame, System.Action func )
	{
		for( int i=0; i<frame; i++ )
		{
			yield return new WaitForEndOfFrame();
			if( PauseManager.Instance.IsPause )
			{
				i--;
			}
		}
		
		func();
	}
}
