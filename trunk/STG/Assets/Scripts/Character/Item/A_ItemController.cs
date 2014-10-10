/*===========================================================================*/
/*
*     * FileName    :A_ItemController.cs
*
*     * Description : .
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
public abstract class A_ItemController : GameMonoBehaviour
{
	/// <summary>
	/// 最初のツイーン処理.
	/// </summary>
	[SerializeField]
	protected ObjectMoveTween refFirstTween;
	
	/// <summary>
	/// 落ちるツイーン処理.
	/// </summary>
	[SerializeField]
	protected ObjectMoveTween refFallTween;

	[SerializeField]
	private float random;

	// Use this for initialization
	public override void Start ()
	{
		refFirstTween.data.targetPosition += Trans.localPosition;
		refFallTween.data.targetPosition += Trans.localPosition + Vector3.right * Random.Range( -random, random );
	}

	public bool IsFirstMove
	{
		get
		{
			return !refFirstTween.IsComplete;
		}
	}

	public abstract void StartChasePlayer();

	public abstract void OnPlayerCollide();
}
