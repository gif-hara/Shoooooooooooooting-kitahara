/*===========================================================================*/
/*
*     * FileName    : PositionLerpSetter.cs
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
	/// 二点間のTransformの正規化した座標に設定するコンポーネント.
	/// </summary>
	public class PositionLerpSetter : MonoBehaviour
	{
		[SerializeField]
		private Transform refFrom;
		
		[SerializeField]
		private Transform refTo;

		[SerializeField]
		private GameDefine.WorldSpaceType worldSpaceType = GameDefine.WorldSpaceType.Local;

		[SerializeField]
		private float duration;
		
		private Transform cachedTrans;
		
		void Start ()
		{
			this.cachedTrans = transform;
		}
		
		void Update ()
		{
			if( this.worldSpaceType == GameDefine.WorldSpaceType.Local )
			{
				this.cachedTrans.localPosition = Vector3.Lerp( refFrom.localPosition, refTo.localPosition, this.duration );
			}
			else
			{
				this.cachedTrans.position = Vector3.Lerp( refFrom.position, refTo.position, this.duration );
			}
		}
	}
}
