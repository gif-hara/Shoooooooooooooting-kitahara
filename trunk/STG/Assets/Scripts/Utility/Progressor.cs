/*===========================================================================*/
/*
*     * FileName    : Progressor.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 値を一つ持ち進捗を管理するコンポーネント.
/// </summary>
public class Progressor : MonoBehaviour
{
	/// <summary>
	/// 進捗管理値を加算する.
	/// 引数に int value が入る.
	/// </summary>
	public const string RequestMessage = "OnRequestProgressor";

	/// <summary>
	/// 進捗を進めた際のメッセージ.
	/// 引数に int value が入る.
	/// </summary>
	public const string AdvanceMessage = "OnAdvanceProgressor";

	/// <summary>
	/// 進捗値が変更された際のメッセージ.
	/// </summary>
	public const string ModifiedMessage = "OnModifiedProgress";

	/// <summary>
	/// 完了時のメッセージを受け取るオブジェクトの参照.
	/// </summary>
	[SerializeField]
	private List<GameObject> refReceiver;

	private int max = 0;

	/// <summary>
	/// 進捗値.
	/// </summary>
	private int progress = 0;

	void OnRequestProgressor( int value )
	{
		this.max += value;
		this.Notify();
	}

	void OnAdvanceProgressor( int value )
	{
		this.progress += value;
		this.Notify();
	}

	private void Notify()
	{
		this.refReceiver.ForEach( g =>
		{
			g.BroadcastMessage( ModifiedMessage, ((float)this.progress / this.max) );
		});
	}
}
