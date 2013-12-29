/*===========================================================================*/
/*
*     * FileName    : ObjectMoveITweenPath.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ObjectMoveITweenPath : A_ObjectMove
{
	protected override void InitMove()
	{
		base.InitMove();
		var nodes = new List<Vector3>( data.prefabiTweenPath.GetComponent<iTweenPath>().nodes );
		for( int i=0; i<nodes.Count; i++ )
		{
			var path = nodes[i];
			nodes[i] = new Vector3( path.x + data.offset.x, path.y + data.offset.y, path.z );
		}
		
		if( data.isReverse )
		{
			for( int i=0,imax=nodes.Count; i<imax; i++ )
			{
				nodes[i] = new Vector3( -nodes[i].x, nodes[i].y, nodes[i].z );
			}
		}
		
		refTrans.position = nodes[0];
		iTween.MoveTo( refTrans.gameObject, iTween.Hash(
			"path", nodes.ToArray(),
			"time", data.durationFrame,
			"oncompletetarget", gameObject,
			"oncomplete", "OnComplete",
			"easetype", iTween.EaseType.animationCurve )
			);
		refTrans.gameObject.GetComponent<iTween>().curve = data.curve0;
	}
	protected override void UpdateMove()
	{
		currentDuration++;
	}
	protected override void Finish ()
	{
	}
	private void OnComplete()
	{
		Destroy( refTrans.gameObject );
	}
}