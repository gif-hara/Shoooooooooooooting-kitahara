//================================================
/*!
    @file   I_DeadEvent.cs

    @brief  敵オブジェクトの死亡イベント基底クラス.

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敵オブジェクトの死亡イベント基底クラス.
/// </summary>
public interface I_DeadEvent
{
	/// <summary>
	/// 死亡処理.
	/// </summary>
	void OnDead();
}
