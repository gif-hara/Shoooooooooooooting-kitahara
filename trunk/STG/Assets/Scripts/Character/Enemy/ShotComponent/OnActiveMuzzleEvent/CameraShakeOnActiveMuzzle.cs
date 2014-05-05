/*===========================================================================*/
/*
*     * FileName    : CameraShakeOnActiveMuzzle.cs
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
public class CameraShakeOnActiveMuzzle : GameMonoBehaviour, I_MuzzleEventActinable
{
	[SerializeField]
	private int delay;

	[SerializeField]
	private int rate;

	[SerializeField]
	private int duration;

	/// <summary>
	/// 銃口がアクティブになった際のイベント.
	/// </summary>
	public void OnActiveMuzzle()
	{
		CameraShake.Begin( gameObject, delay, rate, duration );
	}
}
