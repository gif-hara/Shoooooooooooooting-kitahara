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
	/// プレイヤーミス時のイベントメッセージ.
	/// </summary>
	public static string MissEventMessage = "OnMiss";

	/// <summary>
	/// 敵死亡時のイベントメッセージ.
	/// </summary>
	public static string DeadEventMessage = "OnDead";

	/// <summary>
	/// 敵ダメージ時のイベントメッセージ.
	/// </summary>
	public static string DamageEventMessage = "OnDamage";

	public float ColliderLayer = 0.0f;
	
	public override void Awake()
	{
		base.Awake();
		Instance = this;
	}
}
