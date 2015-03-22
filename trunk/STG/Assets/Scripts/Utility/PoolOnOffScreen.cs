/*===========================================================================*/
/*
*     * FileName    : PoolOnOffScreen.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 画面外へ移動したらObjectPoolへプールするコンポーネント.
/// </summary>
public class PoolOnOffScreen : EventOnOffScreen
{
	protected override void Action ()
	{
		ObjectPool.Instance.ReleaseGameObject( gameObject );
	}
}
