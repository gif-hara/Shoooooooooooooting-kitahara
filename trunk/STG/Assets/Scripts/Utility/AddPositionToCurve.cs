/*===========================================================================*/
/*
*     * FileName    :AddPositionToCurve.cs
*
*     * Description : アニメーションカーブによって座標加算を行うコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// アニメーションカーブによって座標加算を行うコンポーネント.
/// </summary>
public class AddPositionToCurve : MonoBehaviour
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
	private AnimationCurve curve;

	private int currentDuration = 0;

	void LateUpdate ()
	{
		var pos = refTarget.position;
		int t = currentDuration % duration;
		refTarget.position = pos + Vector3.Lerp( from, to, curve.Evaluate( (float)t / (float)duration ) );
		currentDuration++;
	}
}
