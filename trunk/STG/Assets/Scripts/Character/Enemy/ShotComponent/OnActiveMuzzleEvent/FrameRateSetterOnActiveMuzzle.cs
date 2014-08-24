/*===========================================================================*/
/*
*     * FileName    : FrameRateSetterOnActiveMuzzle.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 銃口がアクティブになった際にフレームレートを設定するコンポーネント.
/// </summary>
public class FrameRateSetterOnActiveMuzzle : GameMonoBehaviour, I_MuzzleEventActinable
{
	[SerializeField]
	private int frameRate;

	[SerializeField]
	private int delay;

	/// <summary>
	/// 銃口がアクティブになった際のイベント.
	/// </summary>
	public void OnActiveMuzzle()
	{
		FrameRateUtility.StartCoroutine( delay, () =>
		{
			Application.targetFrameRate = frameRate;
		} );
	}
}
