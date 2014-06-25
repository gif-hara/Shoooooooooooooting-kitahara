//================================================
/*!
    @file   A_StageTimeLineActionConditioner.cs

    @brief  A_StageTimeLineActionableのアクション処理を行うか条件を付与する抽象コンポーネント.

    @author Hiroki Kitahara.

    Copyright(C) CyberConnect2 Co., Ltd. All rights reserved.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A_StageTimeLineActionableのアクション処理を行うか条件を付与する抽象コンポーネント.
/// </summary>
public abstract class A_StageTimeLineActionConditioner : GameMonoBehaviour
{
	/// <summary>
	/// 判定処理.
	/// </summary>
	public abstract bool Condition();
}
