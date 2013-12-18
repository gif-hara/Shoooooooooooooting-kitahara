/*===========================================================================*/
/*
*     * FileName    : GameDefine.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class GameDefine : A_Singleton<GameDefine>
{
	/// <summary>
	/// ミス時のイベントメッセージ.
	/// </summary>
	public static string MissEventMessage = "OnMiss";

	public float ColliderLayer = 0.0f;
	
	public override void Awake()
	{
		base.Awake();
		Instance = this;
	}
}
