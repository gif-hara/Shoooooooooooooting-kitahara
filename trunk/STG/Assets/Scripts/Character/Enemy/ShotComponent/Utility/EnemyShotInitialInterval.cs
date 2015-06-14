/*===========================================================================*/
/*
*     * FileName    : EnemyShotInitialInterval.cs
*
*     * Description : 敵弾発射間隔の初期化コンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyShotInitialInterval : MonoBehaviourExtension, I_Poolable
{
	/// <summary>
	/// 要素.
	/// </summary>
	public EnemyShotCreateComponent.Element element;

	public override void Start()
	{
		GetComponent<EnemyShotCreator>().interval = element.EvaluteFloorToInt();
	}

	public void OnAwakeByPool( bool used )
	{
		if( used )
		{
			this.Start();
		}
	}

	public void OnReleaseByPool()
	{

	}
}
