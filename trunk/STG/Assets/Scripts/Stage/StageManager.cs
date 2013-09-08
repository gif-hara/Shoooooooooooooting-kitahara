/*===========================================================================*/
/*
*     * FileName    : StageManager.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StageManager : GameMonoBehaviour
{
	/// <summary>
	/// 敵生成者プレハブ.
	/// </summary>
	public GameObject prefabEnemyCreator;
	
	/// <summary>
	/// フェードアクションプレハブ.
	/// </summary>
	public GameObject prefabFadeAction;
	
	/// <summary>
	/// ストップアクションプレハブ.
	/// </summary>
	public GameObject prefabStopAction;
	
	/// <summary>
	/// プレハブ生成プレハブ.
	/// </summary>
	public GameObject prefabPrefabCreator;
	
	/// <summary>
	/// タイムライン.
	/// </summary>
	public int timeLine;
	
	public List<A_StageTimeLineActionable> actionableList;
	
	public const float StageX = 800.0f;
	
	public const float StageY = 600.0f;
	
	private List<A_StageTimeLineActionable> currentActionableList = new List<A_StageTimeLineActionable>();
	
	public override void Awake()
	{
		base.Awake();
		ReferenceManager.refStageManager = this;
	}
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		InitActionableList();
		SetNextActionableList();
	}

	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		Action();
		timeLine++;
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		float size = 100000.0f;
		Gizmos.DrawWireCube( new Vector3( 0.0f, (size / 2.0f) + (StageY / 2.0f), 0.0f ), new Vector3( StageX, size, 0.0f ) );
		
		Gizmos.color = Color.green;
		Gizmos.DrawLine( new Vector3( 0.0f, 1.0f, 0.0f ), new Vector3( 0,  2.0f, 0.0f ) );
		
		Gizmos.color = new Color( 0.9f, 0.75f, 0.7f, 1.0f );
		Gizmos.DrawLine( new Vector3( -StageX / 2.0f, (StageY / 2.0f ) + timeLine, 0.0f ), new Vector3( 0.0f, (StageY / 2.0f ) + timeLine, 0.0f ) );
	}
	
	public void SetTimeLine( int _timeLine )
	{
		timeLine = _timeLine;
	}
	
	public void StartTimeLine()
	{
		enabled = true;
	}
	
	public void StopTimeLine()
	{
		enabled = false;
	}
	
	private void Action()
	{
		if( currentActionableList.Count == 0 )	return;
		
		if( currentActionableList[0].timeLine == timeLine )
		{
			currentActionableList.ForEach( (obj) =>
			{
				obj.Action();
			});
			
			SetNextActionableList();
		}
	}
	
	private void InitActionableList()
	{
		actionableList.Clear();
		for( int i=0,imax=Trans.childCount; i<imax; i++ )
		{
			var creator = Trans.GetChild( i ).GetComponent<A_StageTimeLineActionable>();
			if( creator == null )	continue;
			
			actionableList.Add( creator );
		}
		actionableList.RemoveAll( (obj) => obj.timeLine < timeLine );
		actionableList.Sort( (x, y) => x.timeLine - y.timeLine );
	}
	
	private void SetNextActionableList()
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
