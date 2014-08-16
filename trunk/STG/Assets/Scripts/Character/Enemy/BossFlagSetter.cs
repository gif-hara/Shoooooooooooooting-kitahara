//================================================
/*!
    @file   BossFlagSetter.cs

    @brief  ボスフラグを設定するコンポーネント.

    @author Hiroki Kitahara.

    Copyright(C) CyberConnect2 Co., Ltd. All rights reserved.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ボスフラグを設定するコンポーネント.
/// </summary>
public class BossFlagSetter : GameMonoBehaviour
{
	[SerializeField]
	private GameDefine.BossType bossType;

	// Use this for initialization
	public override void Start ()
	{
		GameManager.SetBossType( bossType );
	}

	void OnDestroy()
	{
		GameManager.EndBoss();
	}
}
