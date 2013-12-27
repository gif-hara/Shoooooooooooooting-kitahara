//================================================
/*!
    @file   I_DamageEvent.cs

    @brief  敵のダメージ処理イベント基底クラス.

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敵のダメージ処理イベント基底クラス.
/// </summary>
public interface I_DamageEvent
{
	/// <summary>
	/// ダメージ処理.
	/// </summary>
	void OnDamage( float damage );
}
