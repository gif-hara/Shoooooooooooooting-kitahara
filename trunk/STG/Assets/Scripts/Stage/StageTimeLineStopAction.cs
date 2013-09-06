/*===========================================================================*/
/*
*     * FileName    : StageTimeLineStopAction.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StageTimeLineStopAction : A_StageTimeLineActionable
{
	/// <summary>
	/// 停止遅延時間.
	/// </summary>
	public int delayDuration;
	
	/// <summary>
	/// 条件が満たなかった場合の強制終了デュラーション.
	/// </summary>
	public int exceptionDuration;
	
	/// <summary>
	/// 停止処理を解除するのに必要な敵ID.
	/// </summary>
	public int needDestroyEnemyId;
	
	/// <summary>
	/// 停止処理を解除するのに必要な倒す敵の数.
	/// </summary>
	public int needDestroyEnemyNum;
	
	/// <summary>
	/// タイムライン更新を停止させるか.
	/// </summary>
	private bool isStop = false;
	
	/// <summary>
	/// 停止中のタイムライン.
	/// </summary>
	private int stoppingTimeLine = 0;
	
	/// <summary>
	/// 停止処理開始時の敵死亡数保持.
	/// </summary>
	private int destroyEnemyNum = 0;
	
	void Update()
	{
		if( !isStop )	return;
		
		UpdateDelayDuration();
		
		if( IsEndStop )
		{
			EndStop();
		}
		
		if( delayDuration <= 0 )
		{
			stoppingTimeLine++;
		}
	}
	/// <summary>
	/// 停止処理を終了するか？.
	/// </summary>
	/// <returns>
	/// <c>true</c> if this instance is end stop; otherwise, <c>false</c>.
	/// </returns>
	private bool IsEndStop
	{
		get
		{
			return
				stoppingTimeLine >= exceptionDuration ||
				( destroyEnemyNum + needDestroyEnemyNum ) <= GameManager.DestroyEnemyNumList[needDestroyEnemyId];
		}
	}
	private void UpdateDelayDuration()
	{
		if( IsEndStop )	return;
		if( delayDuration <= 0 )	return;
		
		delayDuration--;
		
		if( delayDuration == 0 )
		{
			ReferenceManager.refStageManager.StopTimeLine();
		}
	}
	/// <summary>
	/// 停止処理の終了.
	/// </summary>
	private void EndStop()
	{
		ReferenceManager.refStageManager.StartTimeLine();
		Destroy( gameObject );
	}
	
	public override void Action()
	{
		isStop = true;
		destroyEnemyNum = GameManager.DestroyEnemyNumList[needDestroyEnemyId];
		
		if( delayDuration <= 0 )
		{
			ReferenceManager.refStageManager.StopTimeLine();
		}
	}
	
	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}] TimeLineStop", timeLine );
		}
	}
}
