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
	[System.Serializable]
	public enum DifficultyType : int
	{
		Easy,
		Normal,
		Hard,
		Hell,
		Extra,
	}

	public enum GameModeType : int
	{
		PlayerInput,
		Replay,
	}

	public enum PlayStyleType : int
	{
		NewGame,
		Practice,
	}

	public enum StageType : int
	{
		Stage1,
		Stage2,
		Stage3,
		Stage4,
		Stage5,
		NormalClear,
		ReverseClear,
		Extra,
		ExtraClear,
		BossRush,
		BossRushClear,
	}

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

	/// <summary>
	/// ボスタイプ.
	/// </summary>
	public enum BossType : int
	{
		None,
		MiddleBoss,
		Boss,
	}

	public static readonly Rect Screen = new Rect( -400.0f, 300.0f, 400.0f, -300.0f );

	public static readonly string[] playerNames =
	{
		"Tri-act Z",
		"Tri-act S",
		"Tri-act G",
		"Scissor Side Z",
		"Scissor Side S",
		"Scissor Side G",
	};

	/// <summary>
	/// プレイヤーの無敵時間を設定した際のメッセージ.
	/// 引数に<c>int invincibleTime</c>が入る.
	/// </summary>
	public const string SetPlayerInvincibleMessage = "OnSetPlayerInvincible";

	/// <summary>
	/// プレイヤーミス時のイベントメッセージ.
	/// </summary>
	public const string MissEventMessage = "OnMiss";

	/// <summary>
	/// プレイヤー復活時のメッセージ.
	/// </summary>
	public const string ResurrectionMessage = "OnResurrection";

	/// <summary>
	/// 敵死亡時のイベントメッセージ.
	/// </summary>
	public const string DeadEventMessage = "OnDead";

	/// <summary>
	/// 敵ダメージ時のイベントメッセージ.
	/// </summary>
	public const string DamageEventMessage = "OnDamage";

	/// <summary>
	/// EnemyShotCreatorが全弾出し切った際のメッセージ.
	/// </summary>
	public const string EnemyShotCreatorFreezeMessage = "OnFreezeEnemyShotCreator";

	/// <summary>
	/// 銃口がアクティブになった際のメッセージ.
	/// </summary>
	public const string ActiveMuzzleMessage = "OnActiveMuzzle";

	/// <summary>
	/// 銃口が非アクティブになった際のメッセージ.
	/// </summary>
	public const string DeactiveMuzzleMessage = "OnDeactiveMuzzle";

	/// <summary>
	/// 敵弾生成メッセージ.
	/// </summary>
	public const string EnemyShotCreateMessage = "OnEnemyShotCreate";

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

	/// <summary>
	/// ヒットポイントイベント時にゲームオブジェクトが死亡するメッセージ.
	/// </summary>
	public const string GameObjectDestroyOnHitPointChangeEventMessage = "OnGameObjectDestroyOnHitPointChangeEvent";

	/// <summary>
	/// リザルト開始時のメッセージ
	/// </summary>
	public const string StartResultMessage = "OnStartResult";

	/// <summary>
	/// リザルト終了時のメッセージ.
	/// </summary>
	public const string EndResultMessage = "OnEndResult";

	/// <summary>
	/// ステージ開始時のメッセージ.
	/// </summary>
	public const string StartStageMessage = "OnStartStage";

	/// <summary>
	/// ボスバトル開始時のメッセージ.
	/// </summary>
	public const string StartBossBattleMessage = "OnStartBossBattle";

	/// <summary>
	/// ボスバトル終了時のメッセージ.
	/// </summary>
	public const string EndBossBattleMessage = "OnEndBossBattle";

	/// <summary>
	/// スコア変更時のメッセージ.
	/// </summary>
	public const string ModifiedScoreMessage = "OnModifiedScore";

	/// <summary>
	/// プレイヤーが生成された時のメッセージ.
	/// </summary>
	public const string SpawnPlayerMessage = "OnSpawnPlayer";

	/// <summary>
	/// エクステンドした際のメッセージ.
	/// </summary>
	public const string ExtendMessage = "OnExtend";

	/// <summary>
	/// SPモードに必要なゲージ量が変更された際のメッセージ.
	/// </summary>
	public const string ModifiedNeedSpecialGaugeMessage = "OnModifiedNeedSpecialGauge";

	/// <summary>
	/// SPが変更された際のメッセージ.
	/// </summary>
	public const string ModifiedSpecialPointMessage = "OnModifiedSpecialPoint";
	
	/// <summary>
	/// ポーズ入力処理を受け付けるするメッセージ.
	/// </summary>
	public const string EnableInputPauseMessage = "OnEnableInputPause";

	/// <summary>
	/// ポーズ入力処理を禁止するメッセージ.
	/// </summary>
	public const string DisableInputPauseMessage = "OnDisableInputPause";
	
	/// <summary>
	/// コンティニュー開始時のメッセージ.
	/// </summary>
	public const string StartContinueMessage = "OnStartContinue";

	/// <summary>
	/// コンティニューした際のメッセージ.
	/// </summary>
	public const string ContinueMessage = "OnContinue";
	
	public override void Awake()
	{
		base.Awake();
		Instance = this;
	}

	public static string StageTypeString( StageType stageType )
	{
		string[] result =
		{
			"Stage1",
			"Stage2",
			"Stage3",
			"Stage4",
			"Stage5",
			"Clear",
			"True Clear",
			"Extra",
			"EX Clear",
			"Boss Rush",
			"BR Clear",
		};

		return result[(int)stageType];
	}
}
