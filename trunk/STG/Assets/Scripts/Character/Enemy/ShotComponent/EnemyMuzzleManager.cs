/*===========================================================================*/
/*
*     * FileName    :EnemyMuzzleManager.cs
*
*     * Description : 敵銃口管理者クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敵銃口管理者クラス.
/// </summary>
public class EnemyMuzzleManager : GameMonoBehaviour, I_EnemyShotCreatorEvent
{
	/// <summary>
	/// 初期発射口Id.
	/// </summary>
	[SerializeField]
	private int id;

	/// <summary>
	/// 銃口リスト.
	/// </summary>
	[SerializeField]
	private List<GameObject> refMuzzleList;

	/// <summary>
	/// 待機時間リスト.
	/// </summary>
	[SerializeField]
	private List<int> waitList;

	/// <summary>
	/// 今起動しているショット生成コンポーネントリスト.
	/// </summary>
	private List<EnemyShotCreator> currentShotCreatorList = null;

	/// <summary>
	/// 弾を出し切ったEnemyShotCreatorの数.
	/// </summary>
	private int endCreateNum = 0;

	void Start()
	{
		for( int i=0,imax=refMuzzleList.Count; i<imax; i++ )
		{
			refMuzzleList[i].SetActive( i == id );
		}

		InitShotCreatorList();
	}
	/// <summary>
	/// 全弾出し切った際のメッセージ.
	/// </summary>
	public void OnFreezeEnemyShotCreator()
	{
		endCreateNum++;
		if( endCreateNum < currentShotCreatorList.Count )	return;

		ChangeMuzzle();
	}
	/// <summary>
	/// currentShotCreatorListの初期化.
	/// </summary>
	private void InitShotCreatorList()
	{
		StartMuzzle();
		currentShotCreatorList = new List<EnemyShotCreator> (refMuzzleList [id].GetComponentsInChildren<EnemyShotCreator> ());
		endCreateNum = 0;
	}
	private void ChangeMuzzle()
	{
		CompleteMuzzle();

		FrameRateUtility.StartCoroutine( waitList[id], () =>
		{
			id = (id + 1) % refMuzzleList.Count;
			InitShotCreatorList();
		});
	}
	private void StartMuzzle()
	{
		refMuzzleList[id].SetActive( true );
		refMuzzleList[id].BroadcastMessage( GameDefine.ActiveMuzzleMessage, SendMessageOptions.DontRequireReceiver );
	}
	/// <summary>
	/// 銃口終了処理.
	/// </summary>
	private void CompleteMuzzle()
	{
		refMuzzleList[id].SetActive( false );
	}
}
