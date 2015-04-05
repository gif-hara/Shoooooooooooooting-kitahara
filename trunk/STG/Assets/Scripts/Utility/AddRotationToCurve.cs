/*===========================================================================*/
/*
*     * FileName    : AddRotationToCurve.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// アニメーションカーブによって回転量を加算するコンポーネント.
/// </summary>
public class AddRotationToCurve : GameMonoBehaviour, I_Poolable
{
	[SerializeField]
	private int duration;

	[SerializeField]
	private Vector3 addRotation;

	[SerializeField]
	private AnimationCurve curve;

	[SerializeField]
	private bool isLoop;

	private Quaternion initialRotation;

	private Quaternion toRotation;

	private int currentDuration = 0;
	
	public override void Update ()
	{
		base.Update ();

		if( PauseManager.Instance.IsPause )	return;
		
		this.Trans.localRotation = Quaternion.Lerp( initialRotation, toRotation, curve.Evaluate( (float)this.currentDuration / this.duration ) );
		currentDuration++;

		if ( !isLoop )
		{
			currentDuration = currentDuration > duration ? duration : currentDuration;
		}
		else
		{
			if( currentDuration > duration )
			{
				currentDuration = 0;
			}
		}
	}

	public void OnAwakeByPool( bool used )
	{
		this.currentDuration = 0;
		this.initialRotation = transform.localRotation;
		this.toRotation = Quaternion.Euler( new Vector3(
			this.initialRotation.eulerAngles.x + addRotation.x,
			this.initialRotation.eulerAngles.y + addRotation.y,
			this.initialRotation.eulerAngles.z + addRotation.z
			));
	}

	public void OnReleaseByPool()
	{
	}
}