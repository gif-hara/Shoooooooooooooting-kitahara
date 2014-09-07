﻿/*===========================================================================*/
/*
*     * FileName    : OnDestroyFromEnemyHitPoint.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MyProject
{
	/// <summary>
	/// OnGameObjectDestroyOnHitPointChangeEventをキャッチして死亡するコンポーネント.
	/// </summary>
	public class OnDestroyFromEnemyHitPoint : MonoBehaviour
	{
		void OnGameObjectDestroyOnHitPointChangeEvent()
		{
			Destroy( gameObject );
		}
	}
}