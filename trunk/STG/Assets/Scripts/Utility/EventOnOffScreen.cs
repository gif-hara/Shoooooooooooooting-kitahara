﻿/*===========================================================================*/
/*
*     * FileName    : EventOnOffScreen.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 画面外へ移動したら何かしらのイベントが発生する抽象クラス.
/// </summary>
public abstract class EventOnOffScreen : GameMonoBehaviour
{
	[SerializeField]
	protected Rect bounds;

    [SerializeField]
    protected int updateInterval;

    private int cachedUpdateInterval;

	private static Rect fixedBounds;

#if UNITY_EDITOR
	public void SetBounds( Rect bounds )
	{
		this.bounds = bounds;
	}
#endif

	void OnDrawGizmos()
	{
		var pos = new Rect(
			transform.localPosition.x + bounds.x,
			transform.localPosition.y + bounds.y,
			transform.localPosition.x + bounds.width,
			transform.localPosition.y + bounds.height
			);
		
		// 左.
		Gizmos.DrawLine( new Vector3( pos.x, pos.y, 0.0f ), new Vector3( pos.x, pos.height, 0.0f ) );
		// 上.
		Gizmos.DrawLine( new Vector3( pos.x, pos.y, 0.0f ), new Vector3( pos.width, pos.y, 0.0f ) );
		// 右.
		Gizmos.DrawLine( new Vector3( pos.width, pos.y, 0.0f ), new Vector3( pos.width, pos.height, 0.0f ) );
		// 下.
		Gizmos.DrawLine( new Vector3( pos.x, pos.height, 0.0f ), new Vector3( pos.width, pos.height, 0.0f ) );
		
		var range = GameDefine.Screen;
		
		// 左.
		Gizmos.DrawLine( new Vector3( range.x, range.y, 0.0f ), new Vector3( range.x, range.height, 0.0f ) );
		// 上.
		Gizmos.DrawLine( new Vector3( range.x, range.y, 0.0f ), new Vector3( range.width, range.y, 0.0f ) );
		// 右.
		Gizmos.DrawLine( new Vector3( range.width, range.y, 0.0f ), new Vector3( range.width, range.height, 0.0f ) );
		// 下.
		Gizmos.DrawLine( new Vector3( range.x, range.height, 0.0f ), new Vector3( range.width, range.height, 0.0f ) );
	}

    public override void Start()
    {
        base.Start();
        this.cachedUpdateInterval = this.updateInterval;
    }
	public override void Update()
	{
        if( this.updateInterval > 0 )
        {
            this.updateInterval--;
            return;
        }

        this.updateInterval = this.cachedUpdateInterval;

		base.Update();

		var pos = Trans.position;
		fixedBounds.Set(
			pos.x + bounds.x,
			pos.y + bounds.y,
			pos.x + bounds.width,
			pos.y + bounds.height
			);
		
		
		var range = GameDefine.Screen;
		if( range.y < fixedBounds.height || range.height > fixedBounds.y ||
		   range.x > fixedBounds.width || range.width < fixedBounds.x )
		{
			Action ();
		}
	}
	
	protected abstract void Action();
}
