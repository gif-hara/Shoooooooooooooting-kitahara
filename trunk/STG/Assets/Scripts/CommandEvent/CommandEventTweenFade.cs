/*===========================================================================*/
/*
*     * FileName    : CommandEventTweenFade.cs
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
public class CommandEventTweenFade : MonoBehaviour
{
	[SerializeField]
	private Color from;

	[SerializeField]
	private Color to;

	[SerializeField]
	private int duration;

	void OnCommandEvent()
	{
		FadeManager.Instance.Begin( from, to, duration );
	}
}
