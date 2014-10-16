/*===========================================================================*/
/*
*     * FileName    : PlayBGM.cs
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
public class PlayBGM : MonoBehaviour
{
	[SerializeField]
	private string label;

	void Start ()
	{
		SoundManager.Instance.PlayBGM( label );
	}
}
