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

	public List<A_StageTimeLineActionable> CurrentActionableList{ get{ return currentActionableList; } }
	private List<A_StageTimeLineActionable> currentActionableList = new List<A_StageTimeLineActionable>();
	
	private Transform parent;
	
	private StageTimeLineManager timeLineManager;

	/// <summary>
	/// Initialize the specified parent and timeLineManager.
	/// </summary>
	/// <param name="parent">Parent.</param>
	/// <param name="timeLineManager">Time line manager.</param>
	public void Initialize( Transform parent, StageTimeLineManager timeLineManager )
	{
		InitializeOnField( parent, timeLineManager );
		InitActionableList();
		SetNextActionableList();
	}
	
	/// <summary>
	/// Initializes the on field.
	/// </summary>
	/// <param name="parent">Parent.</param>
	/// <param name="timeLineManager">Time line manager.</param>
	public void InitializeOnField( Transform parent, StageTimeLineManager timeLineManager )
	{
		this.parent = parent;
		this.timeLineManager = timeLineManager;
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
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
	
	/// <summary>
	/// Alls the sync.
	/// </summary>
	public void AllSync()
	{
//		return;
//		
//		Debug.Log( ActionableList.Count );
//		foreach( var a in ActionableList )
//		{
//			a.GetComponent<A_StageTimeLineActionable>().SyncData();
//		}
	}
	
	/// <summary>
	/// Sort the specified comparison.
	/// </summary>
	/// <param name="comparison">Comparison.</param>
	public void Sort( System.Comparison<A_StageTimeLineActionable> comparison )
	{
		actionableList.Sort( comparison );
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
	
	/// <summary>
	/// Sets the next actionable list.
	/// </summary>
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
