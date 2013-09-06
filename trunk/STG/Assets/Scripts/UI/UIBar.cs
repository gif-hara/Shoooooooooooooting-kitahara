/*===========================================================================*/
/*
*     * FileName    : UIBar.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class UIBar : GameMonoBehaviour
{
	public Transform refContent;
	
	public Vector2 size;
	
	protected float max = 1.0f;
	
	public float Current{ set{ Set( value ); } get{ return current; } }
	protected float current = 0.0f;
	
	public void Initialize( float max, float current )
	{
		this.max = max;
		this.current = current;
	}
	private void Set( float current )
	{
		this.current = current;
		this.current = this.current > this.max ? this.max : this.current;
		refContent.localScale = CurrentSize;
	}
	
	private Vector3 CurrentSize
	{
		get
		{
			float normalize = current / max;
			return new Vector3( size.x * normalize, size.y, 1.0f );
		}
	}
}
