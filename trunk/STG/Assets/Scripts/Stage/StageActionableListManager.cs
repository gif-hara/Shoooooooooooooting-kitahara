//================================================
/*!
    @file   StageActionableListManager.cs

    @brief  ステージのアクション可能オブジェクト管理者クラス.

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class StageActionableListManager
{
	/// <summary>
	/// .
	/// </summary>
	public List<A_StageTimeLineActionable> ActionableList{ set{ actionableList = value; } get{ return actionableList; } }
	[SerializeField]
	private List<A_StageTimeLineActionable> actionableList;
	
	private List<A_StageTimeLineActionable> currentActionableList = new List<A_StageTimeLineActionable>();
	
	private Transform parent;
	
	private StageTimeLineManager timeLineManager;
	
	public void Initialize( Transform parent, StageTimeLineManager timeLineManager )
	{
		InitializeOnField( parent, timeLineManager );
		InitActionableList();
		SetNextActionableList();
	}
	
	public void InitializeOnField( Transform parent, StageTimeLineManager timeLineManager )
	{
		this.parent = parent;
		this.timeLineManager = timeLineManager;
	}
	
	public void Update()
	{
		if( currentActionableList.Count == 0 )	return;
		
		if( currentActionableList[0].timeLine == timeLineManager.TimeLine )
		{
			currentActionableList.ForEach( (obj) =>
			{
				obj.Action();
			});
			
			SetNextActionableList();
		}
	}
	
	public void AllSync()
	{
		return;
		
		Debug.Log( ActionableList.Count );
		foreach( var a in ActionableList )
		{
			a.GetComponent<A_StageTimeLineActionable>().SyncData();
		}
	}
	
	private void InitActionableList()
	{
		actionableList.Clear();
		for( int i=0,imax=parent.childCount; i<imax; i++ )
		{
			var creator = parent.GetChild( i ).GetComponent<A_StageTimeLineActionable>();
			if( creator == null )	continue;
			
			actionableList.Add( creator );
		}
		actionableList.RemoveAll( (obj) => obj.timeLine < timeLineManager.TimeLine );
		actionableList.Sort( (x, y) => x.timeLine - y.timeLine );
	}
	
	public void SetNextActionableList()
	{
		currentActionableList.Clear();
		if( actionableList.Count == 0 )	return;
		
		var actionable = actionableList[0];
		int timeLine = actionable.timeLine;
		do
		{
			timeLine = actionable.timeLine;
			currentActionableList.Add( actionable );
			actionableList.RemoveAt( 0 );
			if( actionableList.Count == 0 )
			{
				break;
			}
			actionable = actionableList[0];
		}while( timeLine == actionable.timeLine );
	}
}
