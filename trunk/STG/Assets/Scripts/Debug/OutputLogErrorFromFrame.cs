/*===========================================================================*/
/*
*     * FileName    : OutputLogErrorFromFrame.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;

/// <summary>
/// .
/// </summary>
public class OutputLogErrorFromFrame : MonoBehaviour
{
	[SerializeField]
	private int frame;

	// Update is called once per frame
	void Update ()
	{
		if( ReferenceManager.Instance.FrameCountRecorder.CurrentFrameCount == frame )
		{
			Debug.LogError( "Stop : " + frame );
			EditorApplication.isPaused = true;
			enabled = false;
		}
	}
}
#endif
