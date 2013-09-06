/*===========================================================================*/
/*
*     * FileName    : EnemyShotCreateComponent.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
#define USE_DEBUG	// デバッグ機能を使うか？.
using UnityEngine;
using System.Collections;


public abstract class EnemyShotCreateComponent : EnemyShotCreateComponentBase
{
	/// <summary>
	/// Element.
	/// </summary>
	[System.Serializable]
	public class Element
	{
		public float min;
		
		public float max;
		
#if USE_DEBUG
		public float current;
#endif
		
		public AnimationCurve curve;
		
		public float Evalute()
		{
			return Evalute( ReferenceManager.Instance.refGameManager.GameLevelNormalize );
		}
		public float Evalute( float t )
		{
			float result = Mathf.Lerp( min, max, curve.Evaluate( t ) );
#if USE_DEBUG
			current = result;
#endif
			return result;
		}
		/// <summary>
		/// Evaluteの切り下げた値を返す.
		/// </summary>
		/// <value>
		/// The evalute floor to int.
		/// </value>
		public int EvaluteFloorToInt()
		{
			return EvaluteFloorToInt( ReferenceManager.Instance.refGameManager.GameLevelNormalize );
		}
		public int EvaluteFloorToInt( float t )
		{
			int result = Mathf.FloorToInt( Evalute( t ) );
#if USE_DEBUG
			current = result;
#endif
			return result;
		}
	}
	
	/// <summary>
	/// 要素.
	/// </summary>
	public Element element;
		
	/// <summary>
	/// オーナーのチューニング処理.
	/// </summary>
	public override void Tuning()
	{
		if( !enableTuning )	return;
		
		if( setType == SetType.Set )
		{
			TuningFromSet();
		}
		else if( setType == SetType.Add )
		{
			TuningFromAdd();
		}
	}
	
	protected abstract void TuningFromSet();
	protected abstract void TuningFromAdd();
}
