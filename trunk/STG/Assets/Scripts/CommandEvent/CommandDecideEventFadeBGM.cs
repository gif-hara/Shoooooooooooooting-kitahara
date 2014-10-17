/*===========================================================================*/
/*
*     * FileName    : CommandDecideEventFadeBGM.cs
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
public class CommandDecideEventFadeBGM : MonoBehaviour
{
	[SerializeField]
	private float volumeFrom;
	
	[SerializeField]
	private float volumeTo;
	
	[SerializeField]
	private int duration;
	
	void OnCommandEvent()
	{
		SoundManager.Instance.FadeBGM( volumeFrom, volumeTo, duration );
	}
}
