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
	/// ステージ切り替えプレハブ.
	/// </summary>
	public GameObject prefabStageChange;
	
	/// <summary>
	/// タイムライン管理者クラス.
	/// </summary>
	public StageTimeLineManager timeLineManager;
	
	public StageActionableListManager actionableListManager;
	
	public const float StageX = 800.0f;
	
	public const float StageY = 600.0f;
	
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
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		float size = 100000.0f;
		Gizmos.DrawWireCube( new Vector3( 0.0f, (size / 2.0f) + (StageY / 2.0f), 0.0f ), new Vector3( StageX, size, 0.0f ) );
		
		Gizmos.color = Color.green;
		Gizmos.DrawLine( new Vector3( 0.0f, 1.0f, 0.0f ), new Vector3( 0,  2.0f, 0.0f ) );
		
//		Gizmos.color = new Color( 0.9f, 0.75f, 0.7f, 1.0f );
//		Gizmos.DrawLine( new Vector3( -StageX / 2.0f, (StageY / 2.0f ) + timeLineManager.TimeLine, 0.0f ), new Vector3( 0.0f, (StageY / 2.0f ) + timeLineManager.TimeLine, 0.0f ) );
	}
	
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
	
}
