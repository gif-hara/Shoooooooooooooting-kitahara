/*===========================================================================*/
/*
*     * FileName    : PositionSetterFromDeadEvent.cs
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
	/// 敵死亡時に指定したオブジェクトの座標を設定するコンポーネント.
	/// </summary>
	public class PositionSetterFromDeadEvent : MonoBehaviour
	{
		[SerializeField]
		private Transform refTarget;

		[SerializeField]
		private Vector3 position;

		/// <summary>
		/// 死亡処理.
		/// </summary>
		public void OnDead()
		{
			refTarget.localPosition = position;
		}
	}
}
