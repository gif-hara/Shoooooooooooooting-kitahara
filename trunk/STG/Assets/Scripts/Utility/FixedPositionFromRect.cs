/*===========================================================================*/
/*
*     * FileName    : FixedPositionFromRect.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 指定した矩形からはみ出ないように座標を修正するコンポーネント.
/// </summary>
public class FixedPositionFromRect : MonoBehaviour
{
	[SerializeField]
	private Rect range;

	void OnDrawGizmosSelected()
	{
		Gizmos.DrawLine( new Vector3( range.x, range.y, 0.0f ), new Vector3( range.x, range.height, 0.0f ) );
		Gizmos.DrawLine( new Vector3( range.x, range.y, 0.0f ), new Vector3( range.width, range.y, 0.0f ) );
		Gizmos.DrawLine( new Vector3( range.width, range.y, 0.0f ), new Vector3( range.width, range.height, 0.0f ) );
		Gizmos.DrawLine( new Vector3( range.x, range.height, 0.0f ), new Vector3( range.width, range.height, 0.0f ) );
	}

	void LateUpdate()
	{
		var pos = transform.localPosition;
		pos.x = pos.x < range.x ? range.x : pos.x;
		pos.x = pos.x > range.width ? range.width : pos.x;
		pos.y = pos.y > range.y ? range.y : pos.y;
		pos.y = pos.y < range.height ? range.height : pos.y;
		transform.localPosition = pos;
	}
}
