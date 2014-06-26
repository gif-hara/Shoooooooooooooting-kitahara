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
	[HideInInspector]
	public int interval;
	
	/// <summary>
	/// 名前の拡張.
	/// </summary>
	[HideInInspector]
	public string extensionName;
	
	/// <summary>
	/// オフセット.
	/// </summary>
	public Vector2 offset;
	
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
			(actionableListManager.ActionableList[i] as EnemyCreator).OffsetPosition( offset );
		}
		
		actionableListManager.SetNextActionableList();
	}

	public override void Update()
	{
		base.Update();
		if( !isUpdate )	return;

		if( actionableListManager.CurrentActionableList.Count == 0 )
		{
			Destroy( gameObject );
			return;
		}
		
		actionableListManager.Update();
		timeLineManager.Update();
	}
	
	public override void Action()
	{
		if( !this.CanAction() )
		{
			Destroy( gameObject );
			return;
		}
		isUpdate = true;
	}
	
	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}~{1}] EnemyChunkCreate_{2}", timeLine, timeLine + ((actionableListManager.ActionableList.Count - 1) * interval), extensionName );
		}
	}
}
