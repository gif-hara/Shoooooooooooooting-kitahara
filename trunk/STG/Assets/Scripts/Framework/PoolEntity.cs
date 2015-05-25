/*===========================================================================*/
/*
*     * FileName    : PoolEntity.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// プールされるコンポーネント.
/// </summary>
public class PoolEntity : MonoBehaviour
{
	/// <summary>
	/// キー.
	/// </summary>
	/// <value>The key.</value>
	public int Key{ private set; get; }

	/// <summary>
	/// プールされているか返す.
	/// </summary>
	/// <value><c>true</c> if this instance is pooled; otherwise, <c>false</c>.</value>
	public bool IsPooled{ private set; get; }
	
	/// <summary>
	/// 初期化.
	/// </summary>
	/// <param name="key">Key.</param>
	public void Initialize( int key )
	{
		this.Key = key;
		this.IsPooled = false;
	}
	/// <summary>
	/// プールを行う.
	/// </summary>
	public void Pool()
	{
		this.IsPooled = true;
	}
	/// <summary>
	/// 再利用処理.
	/// </summary>
	public void Reuse()
	{
		this.IsPooled = false;
	}
}
