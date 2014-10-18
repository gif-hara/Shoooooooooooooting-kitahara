/*===========================================================================*/
/*
*     * FileName    : ReferenceManager.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ReferenceManager : A_Singleton<ReferenceManager>
{
	/// <summary>
	/// メインオブジェクトの親オブジェクト.
	/// </summary>
	/// <value>The main object holder.</value>
	public GameObject MainObjectHolder{ get{ return refMainObjectHolder; } }
	[SerializeField]
	private GameObject refMainObjectHolder;

	/// <summary>
	/// エフェクトレイヤー参照.
	/// </summary>
	public GameObject refEffectLayer;
	
	/// <summary>
	/// 敵レイヤー参照.
	/// </summary>
	public GameObject refEnemyLayer;
	
	/// <summary>
	/// 敵弾レイヤー参照.
	/// </summary>
	public GameObject refEnemyShotLayer;
	
	/// <summary>
	/// プレイヤーレイヤー参照.
	/// </summary>
	public GameObject refPlayerLayer;
	
	/// <summary>
	/// プレイヤー弾レイヤー参照.
	/// </summary>
	public GameObject refPlayerShotLayer;
	
	/// <summary>
	/// UIレイヤー参照.
	/// </summary>
	public GameObject refUILayer;
	
	/// <summary>
	/// プレイヤー参照.
	/// </summary>
	public Player Player
	{
		set
		{
			refPlayer = value;
			refUILayer.BroadcastMessage( GameDefine.SpawnPlayerMessage, refPlayer.Id, SendMessageOptions.DontRequireReceiver );
		}
		get
		{
			return refPlayer;
		}
	}
	private Player refPlayer;
	
	/// <summary>
	/// ゲーム管理者クラス参照.
	/// </summary>
	public GameManager refGameManager;

	/// <summary>
	/// プレイヤーステータス管理者クラス参照.
	/// </summary>
	public PlayerStatusManager RefPlayerStatusManager{ get{ return refPlayerStatusManager; } }
	[SerializeField]
	private PlayerStatusManager refPlayerStatusManager;

	/// <summary>
	/// スコア管理者クラス参照.
	/// </summary>
	public ScoreManager refScoreManager;

	/// <summary>
	/// 当たり判定管理者クラス参照.
	/// </summary>
	public CollisionManager refCollisionManager;

	/// <summary>
	/// ステージ管理者クラス参照.
	/// </summary>
	public StageManager refStageManager;
	
	/// <summary>
	/// バリアバーUI参照.
	/// </summary>
	public UIBar refBarrierBar;
	
	/// <summary>
	/// カメラの親オブジェクト参照.
	/// シェイク可能なカメラが入っている.
	/// </summary>
	public GameObject refCameraParent;
	
	/// <summary>
	/// 敵ヒットポイントバープレハブ.
	/// </summary>
	public GameObject prefabEnemyHitPointBar;

	/// <summary>
	/// 影管理者クラス.
	/// </summary>
	/// <value>The shadow manager.</value>
	public ShadowManager ShadowManager{ get{ return this.refShadowManager; } }
	[SerializeField]
	private ShadowManager refShadowManager;

	public ReplayDataRecorder ReplayDataRecorder{ get{ return this.refReplayDataRecorder; } }
	[SerializeField]
	private ReplayDataRecorder refReplayDataRecorder;

	public ReplayDataLoader ReplayDataLoader{ get{ return this.refReplayDataLoader; } }
	[SerializeField]
	private ReplayDataLoader refReplayDataLoader;

	public FrameCountRecorder FrameCountRecorder{ get{ return this.refFrameCountRecorder; } }
	[SerializeField]
	private FrameCountRecorder refFrameCountRecorder;

	/// <summary>
	/// 敵プレハブリスト.
	/// </summary>
	public List<GameObject> prefabEnemyList;
	
	/// <summary>
	/// 敵弾プレハブリスト.
	/// </summary>
	public List<GameObject> prefabEnemyShotList;

	public override void Awake()
	{
		base.Awake();
		Instance = this;
	}

	public GameObject GetLayerObject( GameDefine.LayerType type )
	{
		GameObject[] layer =
		{
			refEnemyShotLayer,
			refEnemyLayer,
			refPlayerLayer,
			refPlayerShotLayer,
			refEffectLayer,
			refUILayer,
			null,	// BackgroundLayerは今のところ必要ない？.
		};

		return layer[(int)type];
	}
}
