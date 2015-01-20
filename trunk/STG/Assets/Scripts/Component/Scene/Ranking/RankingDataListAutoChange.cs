/*===========================================================================*/
/*
*     * FileName    : RankingDataListAutoChange.cs
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
public class RankingDataListAutoChange : MonoBehaviour
{
	[SerializeField]
	private RankingDataListObserver refObserver;

	[SerializeField]
	private int delay;

	private int currentDelay;

	private int listIndex = 0;

	void Start ()
	{
		listIndex = (int)GameStatusInterfacer.Difficulty;
		Set();
	}

	void Update()
	{
		if( currentDelay <= 0 )
		{
			listIndex++;
			Set();
		}

		currentDelay--;
	}

	public void AddListIndex( int value )
	{
		listIndex += value;
		if( listIndex < 0 )
		{
			listIndex = (int)GameDefine.DifficultyType.Extra;
		}

		Set();
	}

	private void Set()
	{
		var data = SaveData.Ranking.Instance;
		refObserver.Content = data.DataList.GetData( listIndex );
		currentDelay = delay;
	}
}
