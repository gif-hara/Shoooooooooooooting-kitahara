/*===========================================================================*/
/*
*     * FileName    :EventActionableFromEnemyHitPoint.cs
*
*     * Description : 敵のヒットポイントによるアクション抽象コンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敵のヒットポイントによるアクション抽象コンポーネント.
/// </summary>
public abstract class EventActionableFromEnemyHitPoint : MonoBehaviour
{
	public abstract void Action();
}
