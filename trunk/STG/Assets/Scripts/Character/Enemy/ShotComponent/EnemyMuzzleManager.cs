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
	/// 初期化遅延時間.
	/// </summary>
	[SerializeField]
	private int delay;

	/// <summary>
	/// 銃口リスト.
	/// </summary>
	[SerializeField][HideInInspector]
	public List<GameObject> refMuzzleList;

	/// <summary>
	/// 待機時間リスト.
	/// </summary>
	[SerializeField][HideInInspector]
	public List<int> waitList;

	/// <summary>
	/// 今起動しているEnemyShotCreatorの数.
	/// </summary>
	private int creatorComponentNum = 0;

	/// <summary>
	/// 弾を出し切ったEnemyShotCreatorの数.
	/// </summary>
	private int endCreatorComponentNum = 0;

	public override void Awake()
	{
		for( int i=0,imax=refMuzzleList.Count; i<imax; i++ )
		{
			refMuzzleList[i].SetActive( false );
		}
	}
	public override void Start()
	{
		FrameRateUtility.StartCoroutine( delay, () =>
		{
			for( int i=0,imax=refMuzzleList.Count; i<imax; i++ )
			{
				if( refMuzzleList[i] == null )	continue;

				refMuzzleList[i].SetActive( i == id );
			}
			
			InitShotCreatorList();
		});
	}
	/// <summary>
	/// 全弾出し切った際のメッセージ.
	/// </summary>
	public void OnFreezeEnemyShotCreator()
	{
		endCreatorComponentNum++;
		if( endCreatorComponentNum < creatorComponentNum )	return;

		ChangeMuzzle();
	}
	/// <summary>
	/// currentShotCreatorListの初期化.
	/// </summary>
	private void InitShotCreatorList()
	{
		if( refMuzzleList[id] == null )	return;

		StartMuzzle();
		creatorComponentNum = refMuzzleList[id].GetComponentsInChildren<EnemyShotCreator>().Length;
		endCreatorComponentNum = 0;
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
		if( refMuzzleList[id] == null )	return;

		refMuzzleList[id].SetActive( true );
		refMuzzleList[id].BroadcastMessage( GameDefine.ActiveMuzzleMessage, SendMessageOptions.DontRequireReceiver );
	}
	/// <summary>
	/// 銃口終了処理.
	/// </summary>
	private void CompleteMuzzle()
	{
		refMuzzleList[id].BroadcastMessage( GameDefine.DeactiveMuzzleMessage, SendMessageOptions.DontRequireReceiver );
		refMuzzleList[id].SetActive( false );
	}

#if UNITY_EDITOR
	public void AddMuzzleList( GameObject muzzleObject, int wait )
	{
		refMuzzleList.Add( muzzleObject );
		waitList.Add( wait );
	}
	public void DeleteMuzzleList( int index )
	{
		refMuzzleList.RemoveAt( index );
		waitList.RemoveAt( index );
	}
#endif
}
