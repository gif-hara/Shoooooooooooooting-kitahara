/*===========================================================================*/
/*
*     * FileName    : TweenRotationFrame.cs
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
public class TweenRotationFrame : MonoBehaviour
{
	[SerializeField]
	private Transform refTarget;

	[SerializeField]
	private Vector3 from;

	[SerializeField]
	private Vector3 to;

	[SerializeField]
	private int duration;

	[SerializeField]
	private int currentDuration;

	[SerializeField]
	private AnimationCurve curve;

	private Quaternion fromQuaternion;

	private Quaternion toQuaternion;

	void Start ()
	{
		this.fromQuaternion = Quaternion.Euler( from );
		this.toQuaternion = Quaternion.Euler( to );
	}
	
	void Update ()
	{
		refTarget.localRotation = Quaternion.Lerp( this.fromQuaternion, this.toQuaternion, curve.Evaluate( (float)currentDuration / duration ) );
		currentDuration++;

		if( currentDuration > duration )
		{
			currentDuration = 0;
		}
	}
}
