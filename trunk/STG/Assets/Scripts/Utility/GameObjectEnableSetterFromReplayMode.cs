/*===========================================================================*/
/*
*     * FileName    : GameObjectEnableSetterFromReplayMode.cs
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
public class GameObjectEnableSetterFromReplayMode : MonoBehaviour
{
	[SerializeField]
	private GameObject refTarget;

	[SerializeField]
	private bool isReplayModeActive;

	// Use this for initialization
	void Start ()
	{
		refTarget.SetActive( (GameStatusInterfacer.GameMode == GameDefine.InputType.Replay) == isReplayModeActive );
	}
}
