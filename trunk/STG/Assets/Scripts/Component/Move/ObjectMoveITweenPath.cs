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
		var refPath = data.prefabiTweenPath.GetComponent<iTweenPath>();
		refTrans.position = refPath.nodes[0];
		iTween.MoveTo( refTrans.gameObject, iTween.Hash(
			"path", refPath.nodes.ToArray(),
			"speed", data.speed,
			"oncompletetarget", gameObject,
			"oncomplete", "OnComplete" )
			);
	}
	protected override void UpdateMove()
	{
		currentDuration++;
	}
	private void OnComplete()
	{
		Destroy( refTrans.gameObject );
	}
}