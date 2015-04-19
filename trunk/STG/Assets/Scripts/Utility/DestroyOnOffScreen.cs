/*===========================================================================*/
/*
*     * FileName    :DestroyOnOffScreen.cs
*
*     * Description : 画面外へ移動したら死亡するコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 画面外へ移動したら死亡するコンポーネント.
/// </summary>
public class DestroyOnOffScreen : EventOnOffScreen
{
#if UNITY_EDITOR
	[ContextMenu( "Replace PoolOnOffScreen." )]
	void OnReplasePoolOnOffScreen()
	{
		gameObject.AddComponent<PoolOnOffScreen>().SetBounds( this.bounds );
	}
#endif

	protected override void Action ()
	{
		Destroy( gameObject );
	}
}
