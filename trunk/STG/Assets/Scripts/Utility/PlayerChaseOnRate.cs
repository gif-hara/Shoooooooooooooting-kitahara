/*===========================================================================*/
/*
*     * FileName    :PlayerChaseOnRate.cs
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
public class PlayerChaseOnRate : GameMonoBehaviour
{
	[SerializeField]
	private Vector3 rate;

	public override void LateUpdate ()
	{
		var pos = ReferenceManager.Instance.refPlayer.Trans.localPosition;
		pos.x *= rate.x;
		pos.z = pos.y * rate.z;;
		pos.y *= rate.y;
		Trans.localPosition = pos;
	}
}
