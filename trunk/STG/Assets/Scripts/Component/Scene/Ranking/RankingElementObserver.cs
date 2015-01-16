/*===========================================================================*/
/*
*     * FileName    : RankingElementObserver.cs
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
public class RankingElementObserver : MonoBehaviour
{
	public const string Message = "OnModifyRankingData";

	public RankingData Content
	{
		set
		{
			content = value;
			gameObject.BroadcastMessage( Message, content, SendMessageOptions.DontRequireReceiver );
		}
	}
	private RankingData content;
}
