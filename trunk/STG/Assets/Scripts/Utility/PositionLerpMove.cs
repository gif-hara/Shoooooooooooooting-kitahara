/*===========================================================================*/
/*
*     * FileName    : PositionLerpMove.cs
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
	/// 二点間のTransformから座標を設定するコンポーネント.
	/// </summary>
	public class PositionLerpMove : MonoBehaviour
	{
		[SerializeField]
		private Transform refFrom;

		[SerializeField]
		private Transform refTo;

		[SerializeField]
		private AnimationCurve curve;

		[SerializeField]
		private int duration;

		[SerializeField]
		private int delay;

		private Transform cachedTrans;

		private int timer;

		void Start ()
		{
			this.cachedTrans = transform;
		}
		
		void Update ()
		{
			if( this.delay > 0 )
			{
				this.delay--;
				return;
			}

			this.cachedTrans.localPosition = Vector3.Lerp( refFrom.localPosition, refTo.localPosition, curve.Evaluate( (float)this.timer / this.duration ) );
			this.timer++;

			if( this.timer > this.duration )
			{
				this.timer = 0;
			}
		}
	}
}
