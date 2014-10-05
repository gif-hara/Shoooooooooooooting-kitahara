/*===========================================================================*/
/*
*     * FileName    : A_SpecialModeContent.cs
*
*     * Description : SPモードコンテンツコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class A_SpecialModeContent : GameMonoBehaviour
{
	/// <summary>
	/// 発動に必要なSPポイント.
	/// </summary>
	public int NeedPoint{ get{ return needPoint; } }
	[SerializeField]
	private int needPoint;
	
	/// <summary>
	/// 発動可能か？.
	/// </summary>
	/// <returns>
	/// <c>true</c> if this instance can execute the specified player; otherwise, <c>false</c>.
	/// </returns>
	/// <param name='player'>
	/// If set to <c>true</c> player.
	/// </param>
	public bool CanExecute()
	{
		return PlayerStatusManager.SpecialPoint >= needPoint;
	}
}
