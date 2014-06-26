//================================================
/*!
    @file   StageTimeLineActionBossExistCondition.cs

    @brief  ボスが存在している時にステージアクションが行えるかどうか判断するコンポーネント.

    @author Hiroki Kitahara.

    Copyright(C) CyberConnect2 Co., Ltd. All rights reserved.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// ボスが存在している時にステージアクションが行えるかどうか判断するコンポーネント.
/// </summary>
public class StageTimeLineActionBossExistCondition : A_StageTimeLineActionConditioner
{
	/// <summary>
	/// 存在している時にアクション可能であるか？.
	/// </summary>
	[SerializeField]
	private bool existAction;

	public override bool Condition ()
	{
		bool bossFlag = GameManager.BossType != GameDefine.BossType.None;

		return bossFlag == existAction;
	}
}
