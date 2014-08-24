/*===========================================================================*/
/*
*     * FileName    : Player.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : GameMonoBehaviour
{
	/// <summary>
	/// コンテンツオブジェクト参照.
	/// </summary>
	public GameObject refContent;
	
	/// <summary>
	/// レンダラーリスト.
	/// </summary>
	public List<Renderer> refRenderer;
	
	/// <summary>
	/// SPポイント加算値.
	/// </summary>
	public float addSpecialPoint;
	
	/// <summary>
	/// 無敵時間.
	/// </summary>
	private int invincibleTime = 0;
	
	/// <summary>
	/// SPモードフラグ.
	/// </summary>
	private bool isSpecialMode = false;
	
	/// <summary>
	/// 初期座標.
	/// </summary>
	private readonly Vector3 initialPosition = new Vector3( 0.0f, -200.0f, 0.0f );
	
	// Use this for initialization
	public override void Awake()
	{
		base.Awake();
		ReferenceManager.refPlayer = this;
	}
	
	public override void Start()
	{
		base.Start();
		Relocation();
	}

	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		UpdateSpecialPoint();
		UpdateRenderer();
		invincibleTime--;
		
		UpdateDebug();
	}
	/// <summary>
	/// SPモードの開始処理.
	/// </summary>
	public void StartSpecialMode( GameObject inSpecialModeContentPrefab )
	{
		if( isSpecialMode )	return;
		
		var spContent = inSpecialModeContentPrefab.GetComponent<A_SpecialModeContent>();
		
		if( !spContent.CanExecute( this ) )	return;
		
		isSpecialMode = true;
		PlayerStatusManager.UseSpecialMode( spContent.NeedPoint );
		InstantiateAsChild( cachedTransform, inSpecialModeContentPrefab );
	}
	/// <summary>
	/// SPモードの終了処理.
	/// </summary>
	public void EndSpecialMode()
	{
		isSpecialMode = false;
	}
	/// <summary>
	/// 無敵時間の設定.
	/// </summary>
	/// <param name='value'>
	/// Value.
	/// </param>
	public void SetInvincible( int value )
	{
		invincibleTime = value;
		ReferenceManager.Instance.GetLayerObject( GameDefine.LayerType.Enemy ).BroadcastMessage( GameDefine.SetPlayerInvincibleMessage, value, SendMessageOptions.DontRequireReceiver );
	}
	/// <summary>
	/// ミス処理.
	/// </summary>
	public void Miss()
	{
		if( IsInvincible )	return;
		
		gameObject.BroadcastMessage (GameDefine.MissEventMessage, SendMessageOptions.DontRequireReceiver);

		PlayerStatusManager.Miss();
		
		refContent.SetActive( false );
		if( PlayerStatusManager.Life > 0 )
		{
			StartCoroutine( ResurrectionCoroutine() );
		}

	}
	/// <summary>
	/// 無敵中であるか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is invincible; otherwise, <c>false</c>.
	/// </value>
	public bool IsInvincible
	{
		get
		{
			if( !refContent.activeSelf )
			{
				return true;
			}
			if( invincibleTime > 0 )
			{
				return true;
			}
			
			return false;
		}
	}
	/// <summary>
	/// 座標を初期値に戻す.
	/// </summary>
	private void Relocation()
	{
		Trans.position = initialPosition;
	}
	/// <summary>
	/// SPポイント更新処理.
	/// </summary>
	private void UpdateSpecialPoint()
	{
		PlayerStatusManager.AddSpecialPoint( addSpecialPoint );
	}
	/// <summary>
	/// レンダラー更新処理.
	/// </summary>
	private void UpdateRenderer()
	{
		if( invincibleTime <= 0 && refRenderer[0].enabled )
		{
			return;
		}
		
		refRenderer.ForEach( (obj) =>
		{
			obj.enabled = !obj.enabled;
		});
	}
	/// <summary>
	/// 復活コルーチン処理.
	/// </summary>
	/// <returns>
	/// The coroutine.
	/// </returns>
	private IEnumerator ResurrectionCoroutine()
	{
		SetInvincible( 240 );
		
		int t = 60;
		while( t > 0 )
		{
			yield return new WaitForEndOfFrame();
			t--;
		}
		
		Relocation();
		refContent.SetActive( true );
	}
	/// <summary>
	/// デバッグ更新処理.
	/// </summary>
	private void UpdateDebug()
	{
		// 無敵デバッグがtrueなら無敵.
		if( DebugManager.IsInvincible )
		{
			invincibleTime = 1;
		}
	}
}
