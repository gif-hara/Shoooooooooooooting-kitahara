/*===========================================================================*/
/*
*     * FileName    : ChangeSceneNameOnNewRecord.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

public class ChangeSceneNameOnNewRecord : MonoBehaviour
{
	[SerializeField]
	private ChangeScene refChangeScene;

	[SerializeField]
	private string nonSaveReplaySceneName;

	[SerializeField]
	private string saveRankingSceneName;

	// Use this for initialization
	void Start ()
	{
		var rank = GameStatusInterfacer.Rank;
		if( rank == -1 )
		{
			if( !GameStatusInterfacer.CanSaveReplay )
			{
				refChangeScene.SetSceneName( nonSaveReplaySceneName );
			}

			return;
		}

		refChangeScene.SetSceneName( saveRankingSceneName );
	}
}
