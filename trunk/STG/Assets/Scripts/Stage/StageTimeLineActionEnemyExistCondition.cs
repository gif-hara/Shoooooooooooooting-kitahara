/*===========================================================================*/
/*
*     * FileName    : StageTimeLineActionEnemyExistCondition.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class StageTimeLineActionEnemyExistCondition : A_StageTimeLineActionConditioner
{
	/// <summary>
	/// 存在している時にアクション可能であるか？.
	/// </summary>
	[SerializeField]
	private bool existAction;

	[SerializeField]
	private int enemyId;

	[SerializeField]
	private int number;

	[SerializeField]
	private Inequality inequality = Inequality.Equal;

	public enum Inequality : int
	{
		Greater,
		Less,
		Equal,
	}

	public override bool Condition ()
	{
		int existCount = ReferenceManager.Instance.refStageManager.ExistEnemyNumber( enemyId );
		bool result = false;
		switch( inequality )
		{
		case Inequality.Greater:
			result = existCount > number;
			break;
		case Inequality.Less:
			result = existCount < number;
			break;
		case Inequality.Equal:
			result = existCount == number;
			break;
		}

		return result == existAction;
	}
}
