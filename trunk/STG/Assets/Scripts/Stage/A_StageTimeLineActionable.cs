/*===========================================================================*/
/*
*     * FileName    : A_StageTimeLineActionable.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class A_StageTimeLineActionable : GameMonoBehaviour
{
	/// <summary>
	/// タイムライン.
	/// </summary>
	[HideInInspector]
	public int timeLine;

	/// <summary>
	/// アクション処理条件コンポーネント.
	/// </summary>
	public A_StageTimeLineActionConditioner refActionConditioner;
	
	/// <summary>
	/// 自分自身の初期座標.
	/// </summary>
//	public static Vector3 myInitialPosition = new Vector3( -400.0f, 300.0f, 0.0f );
	public static Vector3 myInitialPosition = new Vector3( -400.0f, 300.0f, 0.0f );
	
	/// <summary>
	/// アクション処理.
	/// </summary>
	public abstract void Action();
	
	private static StageManager stageManager;
	
	public virtual void OnDrawGizmos()
	{
		if( !IsOutTime )	return;
		
		// TimeLineによる線描画.
//		Gizmos.color = Color.red;
//		Vector3 fromPos = Trans.position + Vector3.left * 400.0f;
//		Gizmos.DrawLine(
//			fromPos,
//			fromPos + Vector3.right * ( StageManager.StageX )
//			);
	}
	/// <summary>
	/// 初期化.
	/// </summary>
	/// <param name='timeLine'>
	/// Time line.
	/// </param>
	public void Initialize( int timeLine )
	{
		this.timeLine = timeLine;
		SyncData();
	}
	/// <summary>
	/// データの同期取り.
	/// </summary>
	public void SyncData()
	{
		gameObject.name = GameObjectName;
//		Trans.position = myInitialPosition + Vector3.up * (timeLine - CurrentStageManager.timeLineManager.TimeLine);
		Trans.position = myInitialPosition + Vector3.up * timeLine;
		//gameObject.SetActive( IsOutTime );
	}
	/// <summary>
	/// アクション処理が可能か返す.
	/// </summary>
	/// <returns><c>true</c> if this instance can action; otherwise, <c>false</c>.</returns>
	protected bool CanAction()
	{
		if( refActionConditioner == null )	return true;

		return refActionConditioner.Condition();
	}
	
	public bool IsOutTime
	{
		get
		{
			return timeLine > CurrentStageManager.timeLineManager.TimeLine;
		}
	}
	/// <summary>
	/// ゲームオブジェクトの名前を返す.
	/// </summary>
	/// <value>
	/// The name of the game object.
	/// </value>
	protected abstract string GameObjectName{ get; }
	
	protected StageManager CurrentStageManager
	{
		get
		{
			if( stageManager == null || stageManager.actionableListManager == null )
			{
				stageManager = GameObject.FindWithTag( "Stage" ).GetComponent<StageManager>();
			}
			return stageManager;
		}
	}

}
