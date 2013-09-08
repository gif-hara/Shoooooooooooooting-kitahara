/*===========================================================================*/
/*
*     * FileName    : A_ObjectMove.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;


public abstract class A_ObjectMove : MonoBehaviourExtension
{
	/// <summary>
	/// コンポーネントに必要なデータの抽象クラス.
	/// </summary>
	[System.Serializable]
	public class Data
	{
		/// <summary>
		/// 目標座標.
		/// </summary>
		public Vector3 targetPosition;
		
		/// <summary>
		/// アニメーションカーブ0.
		/// </summary>
		public AnimationCurve curve0;
		
		/// <summary>
		/// アニメーションカーブ1.
		/// </summary>
		public AnimationCurve curve1;
		
		/// <summary>
		/// スピード.
		/// </summary>
		public float speed;
		
		/// <summary>
		/// 遅延時間（フレーム）.
		/// </summary>
		public int delayFrame;
		
		/// <summary>
		/// 移動に必要な時間（フレーム）.
		/// </summary>
		public int durationFrame;
		
		/// <summary>
		/// 移動させるオブジェクトを死亡させるか.
		/// </summary>
		public bool isDestroy;
		
		/// <summary>
		/// 一定距離画面から離れた場合にオブジェクトを死亡させるか.
		/// </summary>
		public bool isOnOverDistance;
		
		/// <summary>
		/// 回転量の同期取りを行うか.
		/// ObjectMoveChasePlayer.csにて使用.
		/// </summary>
		public bool isSyncRotation;
		
		/// <summary>
		/// 矩形.
		/// </summary>
		public Rect rect;
		
		/// <summary>
		/// 移動タイプの名前.
		/// </summary>
		public ObjectMoveUtility.MoveType moveType;
		
		/// <summary>
		/// 初期化時にSendMessageで呼ばれる関数名.
		/// </summary>
		public string initFuncName;
		
		public Data( ObjectMoveUtility.MoveType type )
		{
			targetPosition = Vector3.zero;
			curve0 = AnimationCurve.Linear( 0.0f, 0.0f, 1.0f, 1.0f );
			delayFrame = 0;
			durationFrame = 1;
			moveType = type;
		}
		
		public Data( Data other )
		{
			this.targetPosition = other.targetPosition;
			this.curve0 = other.curve0;
			this.durationFrame = other.durationFrame;
		}
	}
	
	/// <summary>
	/// 移動させるオブジェクト.
	/// </summary>
	public Transform refTrans;
	
	/// <summary>
	/// 移動処理に必要なデータ.
	/// </summary>
	protected Data data;
	
	/// <summary>
	/// 現在のデュラーション.
	/// </summary>
	protected int currentDuration = 0;
	
	/// <summary>
	/// 移動処理が完了したか？.
	/// </summary>
	public bool IsComplete{ get{ return isComplete; } }
	protected bool isComplete = false;
	
	/// <summary>
	/// 移動初期化処理を行ったか.
	/// </summary>
	private bool isInitMove = false;
	
	/// <summary>
	/// 画面外判定の距離.
	/// </summary>
	protected const float OverDistance = 1500.0f;
	
	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		if( data.delayFrame > 0 )
		{
			data.delayFrame--;
			return;
		}
		
		if( !isInitMove )
		{
			InitMove();
			isInitMove = true;
		}
		
		UpdateMove();
	}
	
	public void InitData( Data data )
	{
		this.data = data;
	}
	/// <summary>
	/// 画面外へ移動した時の死亡処理.
	/// </summary>
	protected void OverDistanceDestroy()
	{
		if( !data.isOnOverDistance )	return;
		
		if( Vector3.Distance( Vector3.zero, refTrans.position ) > OverDistance )
		{
			Destroy( refTrans.gameObject );
		}
	}
	
	protected float Duration
	{
		get
		{
			return (float)currentDuration / data.durationFrame;
		}
	}
	
	protected virtual void InitMove()
	{
		if( !string.IsNullOrEmpty( data.initFuncName ) )
		{
			refTrans.SendMessage( data.initFuncName );
		}
	}
	
	protected abstract void UpdateMove();
}
