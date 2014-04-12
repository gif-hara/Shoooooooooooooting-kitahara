/*===========================================================================*/
/*
*     * FileName    :DecorateInputCreatePrefab.cs
*
*     * Description : 入力処理によってプレハブを生成するコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 入力処理によってプレハブを生成するコンポーネント.
/// </summary>
public class DecorateInputCreatePrefab : A_Decorate<A_InputAction>
{
	[SerializeField]
	private GameObject refParent;
	
	[SerializeField]
	private GameObject prefab;

	public override void Decorate ()
	{
		GameMonoBehaviour.InstantiateAsChild( refParent, prefab );
	}
}
