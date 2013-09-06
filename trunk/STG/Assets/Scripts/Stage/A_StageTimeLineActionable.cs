/*===========================================================================*/
/*
*     * FileName    : A_StageTimeLineActionable.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class A_StageTimeLineActionable : GameMonoBehaviour
{
	/// <summary>
	/// タイムライン.
	/// </summary>
	public int timeLine;
	
	/// <summary>
	/// 自分自身の初期座標.
	/// </summary>
	public static Vector3 myInitialPosition = new Vector3( -400.0f, 300.0f, 0.0f );
	
	/// <summary>
	/// アクション処理.
	/// </summary>
	public abstract void Action();
	
	/// <summary>
	/// 初期化.
	/// </summary>
	/// <param name='timeLine'>
	/// Time line.
	/// </param>
	public void Initialize( int timeLine )
	{
		this.timeLine = timeLine;
		SyncData();
	}
	/// <summary>
	/// データの同期取り.
	/// </summary>
	public void SyncData()
	{
		gameObject.name = GameObjectName;
		Trans.position = myInitialPosition + Vector3.up * timeLine;
	}
	/// <summary>
	/// ゲームオブジェクトの名前を返す.
	/// </summary>
	/// <value>
	/// The name of the game object.
	/// </value>
	protected abstract string GameObjectName{ get; }
}
