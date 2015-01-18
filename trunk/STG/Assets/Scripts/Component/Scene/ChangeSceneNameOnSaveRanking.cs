/*===========================================================================*/
/*
*     * FileName    : ChangeSceneNameOnSaveRanking.cs
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
public class ChangeSceneNameOnSaveRanking : MonoBehaviour
{
	[SerializeField]
	private ChangeScene refChangeScene;

	[SerializeField]
	private string saveReplaySceneName;

	// Use this for initialization
	void Start ()
	{
		if( GameStatusInterfacer.CanSaveReplay )
		{
			refChangeScene.SetSceneName( saveReplaySceneName );
		}
	}
}
