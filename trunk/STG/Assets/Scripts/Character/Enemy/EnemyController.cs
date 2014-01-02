/*===========================================================================*/
/*
*     * FileName    : EnemyController.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyController : EnemyControllerBase
{
	/// <summary>
	/// 敵ID.
	/// </summary>
	/// <value>
	/// The identifier.
	/// </value>
	public int Id{ get{ return id; } }
	public int id;
	
	/// <summary>
	/// ヒットポイント.
	/// </summary>
	public float Hp{ get{ return hp; } }
	public float hp;
	
	/// <summary>
	/// スコアに加算する値.
	/// </summary>
	public int addScore;
	
	/// <summary>
	/// ゲームレベル経験値に加算する値.
	/// </summary>
	public int addGameLevelExperience;
	
	/// <summary>
	/// 無敵時間.
	/// </summary>
	public int invincibleTimer;
	
	/// <summary>
	/// 死亡時に生成するプレハブ.
	/// </summary>
	public GameObject prefabDestroyEffect;
	
	/// <summary>
	/// 死亡時に再生するサウンドラベル.
	/// </summary>
	public string destroySELabel;

	/// <summary>
	/// 死亡時にイベントを発行するオブジェクト.
	/// </summary>
	[SerializeField]
	public GameObject deadEventObject;

	/// <summary>
	/// ダメージ時にイベントを発行するオブジェクト.
	/// </summary>
	[SerializeField]
	public GameObject damageEventObject;
	
	/// <summary>
	/// ショット生成者リスト.
	/// </summary>
	public List<EnemyShotCreator> refShotCreatorList;
	
	/// <summary>
	/// 移動データリスト.
	/// </summary>
	private List<A_ObjectMove.Data> moveDataList;
	
	/// <summary>
	/// 最大ヒットポイント保持.
	/// </summary>
	public float MaxHp{ get{ return maxHp; } }
	private float maxHp;
	
	/// <summary>
	/// 現在の移動コンポーネント.
	/// </summary>
	private A_ObjectMove currentMoveComponent;
	
	/// <summary>
	/// 移動コンポーネントの数.
	/// </summary>
	private int moveComponentCount = 0;
	
	/// <summary>
	/// 死亡しているか？.
	/// </summary>
	public bool IsDead{ get{ return isDead; } }
	private bool isDead = false;
	
	/// <summary>
	/// 拡張更新関数.
	/// </summary>
	public event System.Action updateFunc = null;
		
	public override void Awake()
	{
		base.Awake();
		maxHp = hp;
	}
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		AttachComponent();
	}

	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		UpdateCompleteMoveComponent();
		
		invincibleTimer--;
		
		if( updateFunc != null )
		{
			updateFunc();
		}
	}
	/// <summary>
	/// ダメージ処理.
	/// </summary>
	/// <param name='damage'>
	/// Damage.
	/// </param>
	public override void TakeDamage( float damage )
	{
		if( invincibleTimer > 0 )	return;
		if( isDead )	return;
		
		hp -= damage;
		hp = hp < 0 ? 0 : hp;
		ScoreManager.AddScore( (ulong)GameManager.CollisionEnemyShot );
		if( hp <= 0 )
		{
			Destroy();
		}

		if( damageEventObject != null )
		{
			damageEventObject.BroadcastMessage( GameDefine.DamageEventMessage, damage, SendMessageOptions.DontRequireReceiver );
		}
	}
	/// <summary>
	/// 移動コンポーネントリストの初期化.
	/// </summary>
	/// <param name='moveDataList'>
	/// Move data list.
	/// </param>
	public void InitMoveDataList( List<A_ObjectMove.Data> moveDataList )
	{
		this.moveDataList = new List<A_ObjectMove.Data>();
		if( moveDataList == null )	return;
		
		for( int i=0,imax=moveDataList.Count; i<imax; i++ )
		{
			
			this.moveDataList.Add( moveDataList[i] );
		}
	}
	/// <summary>
	/// 退場処理
	/// </summary>
	public void FallOut()
	{
		refShotCreatorList.ForEach( (obj) =>
		{
			if( obj != null )
			{
				obj.enabled = false;
			}
		});
		
		invincibleTimer = 99999;
	}
	/// <summary>
	/// 強制的に死亡させる.
	/// </summary>
	public void ForceDead()
	{
		isDead = true;
		Destroy( gameObject );
		
		// 死亡イベントの発行.
		deadEventObject.BroadcastMessage( GameDefine.DeadEventMessage, SendMessageOptions.DontRequireReceiver );
	}
	/// <summary>
	/// 正規化したヒットポイントを返す.
	/// </summary>
	/// <value>
	/// The current hit point normalize.
	/// </value>
	public float CurrentHitPointNormalize
	{
		get
		{
			return (float)hp / maxHp;
		}
	}
	/// <summary>
	/// 死亡処理.
	/// </summary>
	protected void Destroy()
	{
		isDead = true;
		Destroy( gameObject );
		
		// スコアの加算.
		ScoreManager.AddScoreRateGameLevel( (ulong)addScore );
		ScoreManager.DestroyEnemy( Trans.position );
		
		// ゲームレベル経験値の加算.
		GameManager.AddGameLevelExperience( addGameLevelExperience );
		
		// 敵死亡数の加算.
		GameManager.DestroyEnemy( id );

		// 死亡イベントの発行.
		deadEventObject.BroadcastMessage( GameDefine.DeadEventMessage, SendMessageOptions.DontRequireReceiver );
	}
	/// <summary>
	/// 移動コンポーネントアタッチ.
	/// </summary>
	private void AttachComponent()
	{
		if( moveDataList == null )	return;
		if( moveComponentCount >= moveDataList.Count )	return;
		
		currentMoveComponent = ObjectMoveUtility.CreateObjectMove( Trans, moveDataList[moveComponentCount++] );
		currentMoveComponent.refTrans = Trans;
	}
	/// <summary>
	/// 移動コンポーネントの完了処理.
	/// </summary>
	private void UpdateCompleteMoveComponent()	
	{
		if( currentMoveComponent == null )	return;
		
		if( currentMoveComponent.IsComplete )
		{
			Destroy( currentMoveComponent.gameObject );
			AttachComponent();
		}
	}
}
