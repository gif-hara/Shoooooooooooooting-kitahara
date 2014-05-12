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
	public enum LayerType : int
	{
		EnemyShot,
		Enemy,
		Player,
		PlayerShot,
		Effect,
		UI,
		Background,
	}

	public static readonly Rect Screen = new Rect( -400.0f, 300.0f, 400.0f, -300.0f );

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

	/// <summary>
	/// EnemyShotCreatorが全弾出し切った際のメッセージ.
	/// </summary>
	public static string EnemyShotCreatorFreezeMessage = "OnFreezeEnemyShotCreator";

	/// <summary>
	/// 銃口がアクティブになった際のメッセージ.
	/// </summary>
	public static string ActiveMuzzleMessage = "OnActiveMuzzle";

	/// <summary>
	/// 銃口が非アクティブになった際のメッセージ.
	/// </summary>
	public static string DeactiveMuzzleMessage = "OnDeactiveMuzzle";

	/// <summary>
	/// 敵弾生成メッセージ.
	/// </summary>
	public static string EnemyShotCreateMessage = "OnEnemyShotCreate";

	/// <summary>
	/// 銃口が非アクティブになった時に敵が死亡するメッセージ.
	/// 引数に<c>int destroyEnemyId</c>が入る.
	/// </summary>
	public const string EnemyDestroyOnDeactiveMuzzleMessage = "OnEnemyDestroyOnDeactiveMuzzleMessage";

	/// <summary>
	/// ヒットポイントイベント時に敵が死亡するメッセージ.
	/// 引数に<c>int destroyEnemyId</c>が入る.
	/// </summary>
	public const string EnemyDestroyOnHitPointChangeEventMessage = "OnEnemyDestroyOnHitPointChangeEvent";

	public override void Awake()
	{
		base.Awake();
		Instance = this;
	}
}
