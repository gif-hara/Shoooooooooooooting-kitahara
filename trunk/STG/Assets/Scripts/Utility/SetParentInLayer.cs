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
public class SetParentInLayer : GameMonoBehaviour, I_Poolable
{
	[SerializeField]
	private Transform refTarget;

	[SerializeField]
	GameDefine.LayerType layerType;

	public override void Start ()
	{
		base.Start ();
		Set ();
	}

	public void OnAwakeByPool( bool used )
	{
		Set();
	}

	public void OnReleaseByPool()
	{
	}

	private void Set()
	{
		if( ReferenceManager == null )	return;
		
		refTarget.parent = ReferenceManager.GetLayerObject( layerType ).transform;
	}
}
