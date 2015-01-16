/*===========================================================================*/
/*
*     * FileName    : FadeBGM.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// .
/// </summary>
public class FadeBGM : MonoBehaviour
{
	[SerializeField]
	private float from;

	[SerializeField]
	private float to;

	[SerializeField]
	private int duration;

	// Use this for initialization
	void Start ()
	{
		SoundManager.Instance.FadeBGM( from, to, duration );
	}
}
