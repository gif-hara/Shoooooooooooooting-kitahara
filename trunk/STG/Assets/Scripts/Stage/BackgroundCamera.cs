/*===========================================================================*/
/*
*     * FileName    :BackgroundCamera.cs
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
public class BackgroundCamera : MonoBehaviour
{
	[SerializeField]
	private iTweenPath refPath;

	[SerializeField]
	private AnimationCurve curve;

	[SerializeField]
	private int duration;

	private Vector3 oldPosition;

	void Start ()
	{
		var nodes = new List<Vector3>( refPath.nodes );

		transform.position = nodes[0];
		iTween.MoveTo( gameObject, iTween.Hash(
			"path", nodes.ToArray(),
			"time", duration,
			"oncompletetarget", gameObject,
			"oncomplete", "OnComplete",
			"easetype", iTween.EaseType.animationCurve,
			"looptype", iTween.LoopType.loop
			)
		              );
		gameObject.GetComponent<iTween>().curve = curve;

		oldPosition = transform.localPosition;
	}
	
	void LateUpdate ()
	{
		if( transform.localPosition == oldPosition )	return;

		transform.localRotation = Quaternion.LookRotation( transform.localPosition - oldPosition );
		oldPosition = transform.localPosition;
	}

	public void OnComplete()
	{
	}
}
