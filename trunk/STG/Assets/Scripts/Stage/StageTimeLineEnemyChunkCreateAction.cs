//================================================
/*!
    @file   StageTimeLineEnemyChunkCreateAction.cs

    @brief  .

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StageTimeLineEnemyChunkCreateAction : A_StageTimeLineActionable
{
	private StageTimeLineManager timeLineManager;
	
	[SerializeField]
	private StageActionableListManager actionableListManager;
	
	/// <summary>
	/// 生成間隔.
	/// </summary>
	public int interval;
	
	private bool isUpdate = false;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		timeLineManager = new StageTimeLineManager();
		
		actionableListManager.InitializeOnField( Trans, timeLineManager );

		for( int i=0,imax=actionableListManager.ActionableList.Count; i<imax; i++ )
		{
			actionableListManager.ActionableList[i].timeLine += interval * i;
		}
		
		actionableListManager.SetNextActionableList();
	}

	public override void Update()
	{
		base.Update();
		if( !isUpdate )	return;
		
		actionableListManager.Update();
		timeLineManager.Update();
	}
	
	public override void Action()
	{
		isUpdate = true;
	}
	
	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}~{1}] EnemyChunkCreate", timeLine, timeLine + ((actionableListManager.ActionableList.Count - 1) * interval) );
		}
	}
}
