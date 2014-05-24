/*===========================================================================*/
/*
*     * FileName    : OnEnemyActionObjectMoveAttach.cs
*
*     * Description : 敵京イベントによるObjectMove系コンポーネントをアタッチするコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// ObjectMove系コンポーネントをアタッチするコンポーネント.
/// </summary>
public class OnEnemyActionObjectMoveAttach : ObjectMoveAttach, I_MuzzleEventActinable
{
	/// <summary>
	/// 銃口がアクティブになった際のイベント.
	/// </summary>
	public void OnActiveMuzzle()
	{
		Attach();
	}
	/// <summary>
	/// 敵弾生成メッセージ.
	/// </summary>
	public void OnEnemyShotCreate()
	{
		Attach();
	}
}
