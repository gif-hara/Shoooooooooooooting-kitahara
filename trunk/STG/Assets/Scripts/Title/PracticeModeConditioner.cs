/*===========================================================================*/
/*
*     * FileName    : PracticeModeConditioner.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

public class PracticeModeConditioner : MonoBehaviour
{
	[SerializeField]
	private GameDefine.DifficultyType difficulty;

	void CatchCondition( ConditionHolder holder )
	{
		holder.IsSuccess = CanPlay;
	}
	private bool CanPlay
	{
		get
		{
			return SaveData.Progresses.Instance.StageClearFrag[(int)difficulty].FindIndex( s => s == true ) != -1;
		}
	}
}
