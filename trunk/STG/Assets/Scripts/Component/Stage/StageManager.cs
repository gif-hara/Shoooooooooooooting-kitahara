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
	/// ステージアクションプレハブリスト.
	/// </summary>
	public List<A_StageTimeLineActionable> prefabActionableObjectList;
		
	/// <summary>
	/// タイムライン管理者クラス.
	/// </summary>
	public StageTimeLineManager timeLineManager;
	
	public StageActionableListManager actionableListManager;

	public int StageId{ get{ return stageId; } }
	[SerializeField]
	private int stageId;

	private List<int> existEnemyIdList = new List<int>();
	
	public override void Awake()
	{
		base.Awake();
		ReferenceManager.refStageManager = this;
	}
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		actionableListManager.Initialize( Trans, timeLineManager );
		Debug.Log( "Stage Start [" + gameObject.name + "] Frame = " + ReferenceManager.Instance.FrameCountRecorder.CurrentFrameCount );
	}

	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		actionableListManager.Update();
		timeLineManager.Update();
		
#if UNITY_EDITOR
		actionableListManager.AllSync();
#endif
	}
	
//	void OnDrawGizmos()
//	{
//		Gizmos.color = Color.yellow;
//		float size = 100000.0f;
//		Gizmos.DrawWireCube( new Vector3( 0.0f, (size / 2.0f) + (StageY / 2.0f), 0.0f ), new Vector3( StageX, size, 0.0f ) );
//		
//		Gizmos.color = Color.green;
//		Gizmos.DrawLine( new Vector3( 0.0f, 1.0f, 0.0f ), new Vector3( 0,  2.0f, 0.0f ) );
//		
////		Gizmos.color = new Color( 0.9f, 0.75f, 0.7f, 1.0f );
////		Gizmos.DrawLine( new Vector3( -StageX / 2.0f, (StageY / 2.0f ) + timeLineManager.TimeLine, 0.0f ), new Vector3( 0.0f, (StageY / 2.0f ) + timeLineManager.TimeLine, 0.0f ) );
//	}
	
	public void SetTimeLine( int _timeLine )
	{
		timeLineManager.TimeLine = _timeLine;
	}
	
	public void StartTimeLine()
	{
		enabled = true;
	}
	
	public void StopTimeLine()
	{
		enabled = false;
	}

	public void AddExistEnemyId( int enemyId )
	{
		this.existEnemyIdList.Add( enemyId );
	}

	public void RemoveExistEnemyId( int enemyId )
	{
		this.existEnemyIdList.Remove( enemyId );
	}

	public int ExistEnemyNumber( int enemyId )
	{
		return this.existEnemyIdList.FindAll( m => m == enemyId ).Count;
	}
}
