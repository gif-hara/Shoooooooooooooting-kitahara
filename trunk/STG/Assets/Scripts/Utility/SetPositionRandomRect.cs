/*===========================================================================*/
/*
*     * FileName    : SetPositionRandomRect.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 指定したTransformの座標を矩形内をランダムで移動させるコンポーネント.
/// </summary>
public class SetPositionRandomRect : MonoBehaviour
{
	[SerializeField]
	private Transform refTarget;

	[SerializeField]
	private Rect rect;

	[SerializeField]
	private Vector2 offset;

	[SerializeField]
	private int delay;

	[SerializeField]
	private int duration;

	// Use this for initialization
	void Start ()
	{
		this.Action();
	}

	private void Action()
	{
		FrameRateUtility.StartCoroutine( this.duration, () =>
		{
			if( enabled )
			{
				refTarget.localPosition = new Vector3(
					Random.Range( rect.x, rect.width ) + offset.x,
					Random.Range( rect.y, rect.height ) + offset.y,
					this.refTarget.localPosition.z
					);
				this.duration = this.delay;
				Action();
			}
		});
	}
}
