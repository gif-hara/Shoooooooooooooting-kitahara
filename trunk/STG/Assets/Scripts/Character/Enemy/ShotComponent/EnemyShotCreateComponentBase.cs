/*===========================================================================*/
/*
*     * FileName    : EnemyShotCreateComponentBase.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotCreateComponentBase : GameMonoBehaviour
{
	/// <summary>
	/// プロパティの設定タイプ.
	/// </summary>
	public enum SetType : int
	{
		/// <summary>
		/// 代入.
		/// </summary>
		Set,
		/// <summary>
		/// 加算.
		/// </summary>
		Add,
	}
		
	/// <summary>
	/// プロパティの設定タイプ.
	/// </summary>
	public SetType setType;

	/// <summary>
	/// Tuning関数を実行するか？.
	/// </summary>
	public bool enableTuning = true;
	
	/// <summary>
	/// 要素を設定するオーナー.
	/// </summary>
	protected EnemyShotCreator owner;
	
	/// <summary>
	/// 初期化.
	/// </summary>
	/// <param name='owner'>
	/// Owner.
	/// </param>
	public virtual void Initialize( EnemyShotCreator owner )
	{
		this.owner = owner;
	}
	/// <summary>
	/// チューニング処理.
	/// </summary>
	public virtual void Tuning()
	{
	}
}
