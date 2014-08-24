/*===========================================================================*/
/*
*     * FileName    : ChaseGameObjectTargetSetterFromSetPlayerInvincible.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MyProject
{
	/// <summary>
	/// プレイヤーの無敵時間設定のイベントをキャッチしてChaseGameObjectの追従オブジェクトを切り替えるコンポーネント.
	/// </summary>
	public class ChaseGameObjectTargetSetterFromSetPlayerInvincible : MonoBehaviour
	{
		[SerializeField]
		private ChaseGameObject refChaseGameObject;

		[SerializeField]
		private Transform refSwitchObject;

		[SerializeField]
		private int additionValue;

		private Transform defaultChaseObject;

		private int invincibleCount = 0;

		void Start()
		{
			this.defaultChaseObject = refChaseGameObject.refChaseObject;
		}

		void OnSetPlayerInvincible( int invincibleTime )
		{
			this.invincibleCount++;
			if( this.invincibleCount == 1 )
			{
				refChaseGameObject.ChangeChaseObject( refSwitchObject );
			}

			FrameRateUtility.StartCoroutine( invincibleTime + additionValue, ChangeDefaultChaseObject );
		}

		private void ChangeDefaultChaseObject()
		{
			this.invincibleCount--;
			if( this.invincibleCount == 0 )
			{
				refChaseGameObject.ChangeChaseObject( this.defaultChaseObject );
			}
		}
	}
}
