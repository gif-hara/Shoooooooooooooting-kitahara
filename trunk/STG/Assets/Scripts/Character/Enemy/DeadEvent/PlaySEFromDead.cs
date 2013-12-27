//================================================
/*!
    @file   PlaySEFromDead.cs

    @brief  敵死亡時にSEを再生するコンポーネント.

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敵死亡時にSEを再生するコンポーネント.
/// </summary>
public class PlaySEFromDead : GameMonoBehaviour, I_DeadEvent
{
	/// <summary>
	/// ラベル.
	/// </summary>
	[SerializeField]
	private string label;

	/// <summary>
	/// 死亡処理.
	/// </summary>
	public void OnDead()
	{
		ReferenceManager.Instance.refSoundManager.Play( label );
	}
}
