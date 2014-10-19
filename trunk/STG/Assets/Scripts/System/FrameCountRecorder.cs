/*===========================================================================*/
/*
*     * FileName    : FrameCountRecorder.cs
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
public class FrameCountRecorder : MonoBehaviour
{
	private int startSceneFrame;

	private int pauseFrame;

	void Start ()
	{
		startSceneFrame = Time.frameCount;
	}

	void Update()
	{
		if( PauseManager.Instance.IsPause )
		{
			pauseFrame++;
		}
	}

	public int CurrentFrameCount
	{
		get
		{
			//Debug.Log( "Time.frameCount = " + Time.frameCount + " sceneStartFrame = " + sceneStartFrame );
			return Time.frameCount - startSceneFrame - pauseFrame;
		}
	}
}
