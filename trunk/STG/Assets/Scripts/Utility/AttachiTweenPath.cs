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
//[ExecuteInEditMode()]
public class BackgroundCamera : MonoBehaviour
{
	[SerializeField]
	private iTweenPath refPath;

	[SerializeField]
	private AnimationCurve curve;

	[SerializeField]
	private int duration;

	[SerializeField]
	private iTween.LoopType loopType = iTween.LoopType.loop;

	[SerializeField]
	private iTweenPath path;

	[SerializeField][Range( 0, 1 )]
	private float debugRange;

	private Vector3 oldPosition;

	void Start ()
	{
		var nodes = new List<Vector3>( refPath.nodes );

		transform.position = nodes[0];
		iTween.MoveTo( gameObject, iTween.Hash(
			"path", nodes.ToArray(),
			"time", duration,
			"oncompletetarget", gameObject,
			"easetype", iTween.EaseType.animationCurve,
			"looptype", loopType
			)
		              );
		gameObject.GetComponent<iTween>().curve = curve;

		oldPosition = transform.localPosition;
	}
	
	void LateUpdate ()
	{
		if( !Application.isPlaying && path != null )
		{
			var pos = iTween.Interp( path.nodes.ToArray(), debugRange );
			var next = iTween.Interp( path.nodes.ToArray(), debugRange + 0.01f );
			transform.localRotation = Quaternion.LookRotation( next - pos );
			transform.localPosition = pos;
		}
		if( transform.localPosition == oldPosition )	return;

		transform.localRotation = Quaternion.LookRotation( transform.localPosition - oldPosition );
		oldPosition = transform.localPosition;
	}
}
