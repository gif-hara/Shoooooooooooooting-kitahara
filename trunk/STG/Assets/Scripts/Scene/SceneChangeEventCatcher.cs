/*===========================================================================*/
/*
*     * FileName    : SceneChangeEventCatcher.cs
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
public class SceneChangeEventCatcher : MonoBehaviour
{
	[SerializeField]
	private int delay;

	void OnStartSceneEffect ( SceneManager.EventCatchData data )
	{
		data.Catch();
		FrameRateUtility.StartCoroutine( delay, () =>{ data.Release(); } );
	}
}
