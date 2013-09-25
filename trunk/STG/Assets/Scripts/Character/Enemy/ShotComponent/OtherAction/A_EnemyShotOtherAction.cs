/*===========================================================================*/
/*
*     * FileName    : A_EnemyShotOtherAction.cs
*
*     * Description : 敵弾発射処理に様々なアクションを行う抽象コンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class A_EnemyShotOtherAction : MonoBehaviourExtension
{
	/// <summary>
	/// その他処理.
	/// </summary>
	public abstract void OtherAction();
}
