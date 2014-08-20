/*===========================================================================*/
/*
*     * FileName    : SetParentInLayer.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 指定したゲームオブジェクトの親を設定するコンポーネント.
/// </summary>
public class SetParentInLayer : GameMonoBehaviour
{
	[SerializeField]
	private Transform refTarget;

	[SerializeField]
	GameDefine.LayerType layerType;

	public override void Start ()
	{
		refTarget.parent = ReferenceManager.GetLayerObject( layerType ).transform;
	}
}
