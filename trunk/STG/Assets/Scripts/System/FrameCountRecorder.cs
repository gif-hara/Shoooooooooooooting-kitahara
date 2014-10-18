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
	private int sceneStartFrame;

	void Start ()
	{
		sceneStartFrame = Time.frameCount;
	}

	public int CurrentFrameCount
	{
		get
		{
			//Debug.Log( "Time.frameCount = " + Time.frameCount + " sceneStartFrame = " + sceneStartFrame );
			return Time.frameCount - sceneStartFrame;
		}
	}
}
