/*===========================================================================*/
/*
*     * FileName    : RandomSetPositionOffScreen.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 画面外の何処かに座標を設定するコンポーネント.
/// </summary>
public class RandomSetPositionOffScreen : MonoBehaviour
{
	public enum OffScreenType : int
	{
		Left,
		Top,
		Right,
		Bottom
	}
	void Start ()
	{
		var type = (OffScreenType)Random.Range( 0, 4 );
		float x = 0.0f;
		float y = 0.0f;
		if( type == OffScreenType.Left )
		{
			x = -400.0f;
			y = Random.Range( -400.0f, 400.0f );
		}
		else if( type == OffScreenType.Top )
		{
			x = Random.Range( -400.0f, 400.0f );
			y = 400.0f;
		}
		else if( type == OffScreenType.Right )
		{
			x = 400.0f;
			y = Random.Range( -400.0f, 400.0f );
		}
		else if( type == OffScreenType.Bottom )
		{
			x = Random.Range( -400.0f, 400.0f );
			y = -400.0f;
		}

		transform.position = new Vector3( x, y, transform.position.z );
	}
}
