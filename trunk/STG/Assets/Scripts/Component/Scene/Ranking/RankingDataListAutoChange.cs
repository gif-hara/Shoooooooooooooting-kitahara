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
		Set();
	}

	void Update()
	{
		if( currentDelay <= 0 )
		{
			Set();
		}

		currentDelay--;
	}

	private void Set()
	{
		var data = SaveData.Ranking.Instance;
		refObserver.Content = data.DataList.GetData( listIndex );
		currentDelay = delay;
		listIndex++;
	}
}
