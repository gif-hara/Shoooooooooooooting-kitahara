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
	[SerializeField]
	private int id;
	
	/// <summary>
	/// ヒットポイント.
	/// </summary>
	public float Hp{ get{ return hp; } }
	[SerializeField]
	private float hp;
	
	/// <summary>
	/// スコアに加算する値.
	/// </summary>
	[SerializeField]
	private int addScore;
	
	/// <summary>
	/// ゲームレベル経験値に加算する値.
	/// </summary>
	[SerializeField]
	private int addGameLevelExperience;
	
	/// <summary>
	/// 無敵時間.
	/// </summary>
	[SerializeField]
	private int invincibleTimer;
	
	/// <summary>
	/// 死亡時にイベントを発行するオブジェクト.
	/// </summary>
	public GameObject DeadEventObject{ set{ deadEventObject = value; } get{ return deadEventObject; } }
	[SerializeField]
	private GameObject deadEventObject;

	/// <summary>
	/// ダメージ時にイベントを発行するオブジェクト.
	/// </summary>
	public GameObject DamageEventObject{ set{ damageEventObject = value; } get{ return damageEventObject; } }
	[SerializeField]
	private GameObject damageEventObject;

	/// <summary>
	/// 描画有効範囲.
	/// </summary>
	public Rect Bounds{ get{ return bounds; } }
	[SerializeField]
	private Rect bounds;

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

	/// <summary>
	/// 死亡時に加算されるSP.
	/// </summary>
	private const float AddSpecialPoint = 0.5f;

	[ContextMenu( "Add Texture Event" )]
	void AddTextureEvent()
	{
		if( gameObject.GetComponentInChildren<TextureFlashFromEnemyHitPoint>() != null )
		{
			Debug.Log( "TextureEvent is already exists." );
			return;
		}

		GameObject eventObject = new GameObject( "TextureEvent" );
		eventObject.transform.parent = transform;
		var textureFlashEvent = eventObject.AddComponent<TextureFlashFromEnemyHitPoint>();
		textureFlashEvent.SelectEnemy( this );
		textureFlashEvent.AllSelect();
	}

	[ContextMenu( "Add Shadow" )]
	void AddShadow()
	{
		//var rendererList = new List<Renderer>();
		Trans.AllVisit( (t) =>
		{
			if( t.GetComponent<MeshRenderer>() != null )
			{
				if( t.gameObject.GetComponent<ShadowCreator>() == null )
				{
					var shadowCreater = t.gameObject.AddComponent<ShadowCreator>();
					var originalMaterial = t.renderer.sharedMaterial;
					var shadowMaterial = Resources.LoadAssetAtPath<Material>( "Assets/DataSources/Material/" + originalMaterial.name + "Shadow.mat" );
					shadowCreater.SetShadowMaterial( shadowMaterial );
					Debug.Log( "Create Shadow " + originalMaterial.name );
				}
				else
				{
					Debug.LogWarning( "Shadow is Already exists." );
				}
			}
		});
	}

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
		JoinStage();
	}

	// Update is called once per frame
	public override void Update()
	{
		base.Update();

		if( PauseManager.Instance.IsPause )	return;
		
		UpdateCompleteMoveComponent();
		
		invincibleTimer--;
		invincibleTimer = invincibleTimer < 0 ? 0 : invincibleTimer;
		
		if( updateFunc != null )
		{
			updateFunc();
		}
	}

	void OnDestroy()
	{
		DefectionStage();
	}

	void OnEnemyDestroyOnDeactiveMuzzleMessage( int destroyEnemyId )
	{
		if( id != destroyEnemyId )	return;
		
		ForceDead();
	}
	
	void OnEnemyDestroyOnHitPointChangeEvent( int destroyEnemyId )
	{
		if( id != destroyEnemyId )	return;
		
		ForceDead();
	}
	
	void OnDrawGizmosSelected()
	{
		var pos = new Rect(
			transform.localPosition.x + bounds.x,
			transform.localPosition.y + bounds.y,
			transform.localPosition.x + bounds.width,
			transform.localPosition.y + bounds.height
			);
		
		// 左.
		Gizmos.DrawLine( new Vector3( pos.x, pos.y, 0.0f ), new Vector3( pos.x, pos.height, 0.0f ) );
		// 上.
		Gizmos.DrawLine( new Vector3( pos.x, pos.y, 0.0f ), new Vector3( pos.width, pos.y, 0.0f ) );
		// 右.
		Gizmos.DrawLine( new Vector3( pos.width, pos.y, 0.0f ), new Vector3( pos.width, pos.height, 0.0f ) );
		// 下.
		Gizmos.DrawLine( new Vector3( pos.x, pos.height, 0.0f ), new Vector3( pos.width, pos.height, 0.0f ) );
	}
	/// <summary>
	/// ヒットポイントの初期化.
	/// </summary>
	/// <param name="hitPoint">Hit point.</param>
	public void InitHitPoint( int hitPoint )
	{
		hp = hitPoint;
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

		if( hp <= 0 )
		{
			Destroy();
		}
		else
		{
			ScoreManager.AddScore( 10 );
		}

		if( damageEventObject != null )
		{
			damageEventObject.BroadcastMessage( GameDefine.DamageEventMessage, damage, SendMessageOptions.DontRequireReceiver );
		}
	}
	public void AddInvincible( int value )
	{
		invincibleTimer += value;
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
		var components = Trans.GetComponentsInChildren<A_ObjectMove>();
		System.Array.ForEach<A_ObjectMove>( components, c =>
		{
			if( c.data.initFuncName != "FallOut" )
			{
				c.enabled = false;
			}
		});
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

		// ゲームレベル経験値の加算.
		GameManager.AddGameLevelExperience( addGameLevelExperience );
		
		// 敵死亡数の加算.
		GameManager.DestroyEnemy( id );

		// 死亡イベントの発行.
		deadEventObject.BroadcastMessage( GameDefine.DeadEventMessage, SendMessageOptions.DontRequireReceiver );

		if( !ReferenceManager.Instance.Player.IsSpecialMode )
		{
			ReferenceManager.Instance.RefPlayerStatusManager.AddSpecialPoint( AddSpecialPoint );
		}
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
	/// ステージ管理者に自分自身を参加させる.
	/// </summary>
	private void JoinStage()
	{
		var stageManager = ReferenceManager.Instance.refStageManager;
		if( stageManager == null )
		{
			return;
		}

		stageManager.AddExistEnemyId( id );
	}

	private void DefectionStage()
	{
		var stageManager = ReferenceManager.Instance.refStageManager;
		if( stageManager == null )
		{
			return;
		}
		
		stageManager.RemoveExistEnemyId( id );
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
