/*===========================================================================*/
/*
*     * FileName    : GameObjectEnableSetterFromDeadEvent.cs
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
	/// 敵死亡時に指定したゲームオブジェクトのアクティブフラグを設定するコンポーネント.
	/// </summary>
	public class GameObjectEnableSetterFromDeadEvent : GameMonoBehaviour
	{
		[SerializeField]
		private List<GameObject> refTarget;

		[SerializeField]
		private bool isActive;

		/// <summary>
		/// 死亡処理.
		/// </summary>
		public void OnDead()
		{
			for( int i=0,imax=refTarget.Count; i<imax; i++ )
			{
				refTarget[i].SetActive( isActive );
			}
		}
	}
}
