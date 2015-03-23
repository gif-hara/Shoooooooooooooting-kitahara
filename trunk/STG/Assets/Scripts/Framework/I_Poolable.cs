/*===========================================================================*/
/*
*     * FileName    : I_Poolable.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// プールされるコンポーネントを証明する基底クラス.
/// </summary>
public interface I_Poolable
{
	/// <summary>
	/// 生成または再利用されたタイミングで呼び出されるイベント.
	/// </summary>
	/// <param name="used">再利用されたか</param>
	void OnAwakeByPool( bool used );

	/// <summary>
	/// 開放されたタイミングで呼び出されるイベント.
	/// </summary>
	void OnReleaseByPool();
}
