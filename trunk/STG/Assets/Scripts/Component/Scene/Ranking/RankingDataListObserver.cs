/*===========================================================================*/
/*
*     * FileName    : RankingDataListObserver.cs
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
public class RankingDataListObserver : MonoBehaviour
{
	public const string Message = "OnModifyRankingDataList";

	public RankingDataList Content
	{
		set
		{
			content = value;
			BroadcastMessage( Message, content, SendMessageOptions.DontRequireReceiver );
		}
	}
	private RankingDataList content;
}
