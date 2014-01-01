/*===========================================================================*/
/*
*     * FileName    : EnemyShotCreatorEvent.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// .
/// </summary>
public class EnemyShotCreatorEvent : EnemyShotCreateComponentSeparate
{
	/// <summary>
	/// イベントリスナーオブジェクト参照.
	/// </summary>
	[SerializeField]
	private GameObject refEventLestener;

	protected override void TuningFromSet ()
	{
		refEventLestener.SendMessage( GameDefine.EnemyShotCreateMessage );
	}

	protected override void TuningFromAdd ()
	{
		TuningFromSet();
	}
}
