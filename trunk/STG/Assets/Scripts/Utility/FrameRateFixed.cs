/*===========================================================================*/
/*
*     * FileName    :FrameRateFixed.cs
*
*     * Description : フレームレート修正コンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// フレームレート修正コンポーネント.
/// </summary>
public class FrameRateFixed : MonoBehaviour
{
	[SerializeField]
	private int fixedFrameRate = 60;

	void Start ()
	{
		Application.targetFrameRate = fixedFrameRate;
	}
}
