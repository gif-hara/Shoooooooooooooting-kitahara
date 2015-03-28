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


public abstract class A_ObjectMove : GameMonoBehaviour, I_Poolable
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
		public Vector3 targetPosition = new Vector3();
		
		/// <summary>
		/// アニメーションカーブ0.
		/// </summary>
		public AnimationCurve curve0 = new AnimationCurve();

		/// <summary>
		/// スピード.
		/// </summary>
		public float speed  = 0.0f;
		
		/// <summary>
		/// 遅延時間（フレーム）.
		/// </summary>
		public int delayFrame = 0;
		
		/// <summary>
		/// 移動に必要な時間（フレーム）.
		/// </summary>
		public int durationFrame = 0;
		
		/// <summary>
		/// 移動させるオブジェクトを死亡させるか.
		/// </summary>
		public bool isDestroy = false;
		
		/// <summary>
		/// 一定距離画面から離れた場合にオブジェクトを死亡させるか.
		/// </summary>
		public bool isOnOverDistance = false;
		
		/// <summary>
		/// 回転量の同期取りを行うか.
		/// ObjectMoveChasePlayer.csにて使用.
		/// </summary>
		public bool isSyncRotation = false;
		
		/// <summary>
		/// 矩形.
		/// </summary>
		public Rect rect = new Rect();
		
		/// <summary>
		/// 移動タイプの名前.
		/// </summary>
		public ObjectMoveUtility.MoveType moveType = ObjectMoveUtility.MoveType.ObjectMoveChasePlayer;
		
		/// <summary>
		/// 初期化時にSendMessageで呼ばれる関数名.
		/// </summary>
		public string initFuncName = "";
		
		/// <summary>
		/// iTweenPathを包含しているプレハブ.
		/// </summary>
		public GameObject prefabiTweenPath = null;
		
		/// <summary>
		/// オフセット.
		/// iTweenのパスの移動に使用する.
		/// </summary>
		public Vector2 offset = new Vector2();
		
		/// <summary>
		/// iTweenのパスを反転させるか.
		/// </summary>
		public bool isReverse = false;
		
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
			this.speed = other.speed;
			this.durationFrame = other.durationFrame;
			this.delayFrame = other.delayFrame;
			this.isDestroy = other.isDestroy;
			this.isOnOverDistance = other.isOnOverDistance;
			this.isSyncRotation = other.isSyncRotation;
			this.rect = other.rect;
			this.moveType = other.moveType;
			this.initFuncName = other.initFuncName;
			this.prefabiTweenPath = other.prefabiTweenPath;
			this.offset = other.offset;
			this.isReverse = other.isReverse;
		}
	}
	
	/// <summary>
	/// 移動させるオブジェクト.
	/// </summary>
	public Transform refTrans;
	
	/// <summary>
	/// 移動処理に必要なデータ.
	/// </summary>
	public Data data;
	
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

	private Data cachedData;
	
	// Update is called once per frame
	public override void Update()
	{
		base.Update();

		if( PauseManager.Instance.IsPause )	return;

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

		if( IsFinish )
		{
			Finish();
		}
	}

	public void OnAwakeByPool( bool used )
	{
		if( !used )
		{
			if( this.data != null )
			{
				this.cachedData = new Data( this.data );
			}
		}
		else
		{
			if( this.cachedData != null )
			{
				this.data = new Data( this.cachedData );
			}
		}
		this.isInitMove = false;
		this.enabled = true;
		this.currentDuration = 0;
		this.isComplete = false;
	}
	
	public void OnReleaseByPool()
	{
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

	protected virtual bool IsFinish
	{
		get
		{
			return currentDuration > data.durationFrame;
		}
	}
	
	protected abstract void UpdateMove();

	protected abstract void Finish();
}
