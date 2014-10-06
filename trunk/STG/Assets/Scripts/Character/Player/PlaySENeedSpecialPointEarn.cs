/*===========================================================================*/
/*
*     * FileName    : PlaySESpecialPointMax.cs
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
public class PlaySENeedSpecialPointEarn : GameMonoBehaviour
{
	[SerializeField]
	private string label;

	private bool isPlay = false;

	void OnModifiedSpecialPoint( float value )
	{
		if( isPlay && value < ReferenceManager.Instance.Player.PrefabSpecialModeContent.NeedPoint )
		{
			isPlay = false;
		}
		else if( !isPlay && value >= ReferenceManager.Instance.Player.PrefabSpecialModeContent.NeedPoint )
		{
			ReferenceManager.Instance.refSoundManager.Play( label );
			isPlay = true;
		}
	}
}
