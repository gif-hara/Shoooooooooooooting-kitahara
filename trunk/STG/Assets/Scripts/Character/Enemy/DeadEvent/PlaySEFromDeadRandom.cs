//================================================
/*!
    @file   PlaySEFromDeadRandom.cs

    @brief  敵死亡時にランダムでSEを再生するコンポーネント.

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敵死亡時にランダムでSEを再生するコンポーネント.
/// </summary>
public class PlaySEFromDeadRandom : GameMonoBehaviour, I_DeadEvent
{
	/// <summary>
	/// ラベル.
	/// </summary>
	[SerializeField]
	private List<string> labels;

	/// <summary>
	/// 死亡処理.
	/// </summary>
	public void OnDead()
	{
		var label = labels[Random.Range( 0, labels.Count )];
		ReferenceManager.Instance.refSoundManager.Play( label );
	}
}
