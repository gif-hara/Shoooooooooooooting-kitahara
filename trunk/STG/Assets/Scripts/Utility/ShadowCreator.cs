/*===========================================================================*/
/*
*     * FileName    : ShadowCreator.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 影オブジェクトを生成するコンポーネント.
/// </summary>
public class ShadowCreator : GameMonoBehaviour
{
	[SerializeField]
	private Material refShadowMaterial;

	private static ShadowManager shadowManager = null;

	public override void Start ()
	{
		base.Start ();
		InitShadowManager();
		var shadow = InstantiateAsChild( ReferenceManager.Instance.refEffectLayer, shadowManager.PrefabShadow.gameObject ).GetComponent<Shadow>();
		shadow.Initialize( Trans, refShadowMaterial );
	}

	private void InitShadowManager()
	{
		if( shadowManager == null )
		{
			shadowManager = ReferenceManager.ShadowManager;
		}
	}
}
