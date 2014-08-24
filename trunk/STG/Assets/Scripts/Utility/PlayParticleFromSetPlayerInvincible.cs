/*===========================================================================*/
/*
*     * FileName    : PlayParticleFromSetPlayerInvincible.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// プレイヤーの無敵時間設定のイベントをキャッチしてパーティクルを再生するコンポーネント.
/// </summary>
public class PlayParticleFromSetPlayerInvincible : MonoBehaviour
{
	[SerializeField]
	private List<ParticleSystem> refParticle;

	private int invincibleCount = 0;

	void OnSetPlayerInvincible( int invincibleTime )
	{
		invincibleCount++;

		refParticle.ForEach( p =>
		{
			p.loop = true;
			p.Play( true );
		});

		FrameRateUtility.StartCoroutine( invincibleTime, EndLoop );
	}

	private void EndLoop()
	{
		invincibleCount--;
		if( invincibleCount == 0 )
		{
			refParticle.ForEach( p =>
			{
				p.loop = false;
			});
		}
	}
}
