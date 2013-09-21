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


public class EnemyShotInitialInterval : MonoBehaviourExtension
{
	/// <summary>
	/// 要素.
	/// </summary>
	public EnemyShotCreateComponent.Element element;
	
	public override void Start()
	{
		GetComponent<EnemyShotCreator>().interval = element.EvaluteFloorToInt();
	}
}
