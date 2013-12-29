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
public class EnemyMuzzleManager : GameMonoBehaviour
{
	/// <summary>
	/// 初期発射口Id.
	/// </summary>
	[SerializeField]
	private int initMuzzleId;

	/// <summary>
	/// 銃口リスト.
	/// </summary>
	[SerializeField]
	private List<GameObject> refMuzzleList;

	void Start()
	{
		for( int i=0,imax=refMuzzleList.Count; i<imax; i++ )
		{
			refMuzzleList[i].SetActive( i == initMuzzleId );
		}
	}
}
