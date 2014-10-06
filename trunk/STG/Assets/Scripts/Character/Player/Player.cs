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
	public int Id{ get{ return id; } }
	[SerializeField]
	private int id;

	/// <summary>
	/// コンテンツオブジェクト参照.
	/// </summary>
	public GameObject refContent;

	[SerializeField]
	private GameObject prefabParticleGraze;

	public A_SpecialModeContent PrefabSpecialModeContent{ get{ return prefabSpecialModeContent; } }
	[SerializeField]
	private A_SpecialModeContent prefabSpecialModeContent;
	
	/// <summary>
	/// 無敵時間.
	/// </summary>
	private int invincibleTime = 0;
	
	/// <summary>
	/// SPモードフラグ.
	/// </summary>
	public bool IsSpecialMode{ get{ return isSpecialMode; } }
	private bool isSpecialMode = false;
	
	/// <summary>
	/// 初期座標.
	/// </summary>
	private readonly Vector3 initialPosition = new Vector3( 0.0f, -200.0f, 0.0f );
	
	// Use this for initialization
	public override void Awake()
	{
		base.Awake();
		ReferenceManager.Player = this;
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
		invincibleTime--;
		
		UpdateDebug();
	}
	/// <summary>
	/// SPモードの開始処理.
	/// </summary>
	public void StartSpecialMode()
	{
		if( isSpecialMode )	return;
		
		if( !prefabSpecialModeContent.CanExecute() )	return;
		
		isSpecialMode = true;
		PlayerStatusManager.UseSpecialMode( prefabSpecialModeContent.NeedPoint );
		InstantiateAsChild( cachedTransform, prefabSpecialModeContent.gameObject );
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
		ReferenceManager.Instance.GetLayerObject( GameDefine.LayerType.Player ).BroadcastMessage( GameDefine.SetPlayerInvincibleMessage, value, SendMessageOptions.DontRequireReceiver );
		ReferenceManager.Instance.GetLayerObject( GameDefine.LayerType.Enemy ).BroadcastMessage( GameDefine.SetPlayerInvincibleMessage, value, SendMessageOptions.DontRequireReceiver );
	}
	/// <summary>
	/// ミス処理.
	/// </summary>
	public void Miss()
	{
		if( IsInvincible )	return;

		// オートボム.
		if( ReferenceManager.RefPlayerStatusManager.IsMaxSpecialPoint )
		{
			AutoSpecialMode();
			return;
		}
		
		gameObject.BroadcastMessage(GameDefine.MissEventMessage, SendMessageOptions.DontRequireReceiver);

		PlayerStatusManager.Miss();
		GameManager.Miss();
		
		refContent.SetActive( false );
		if( PlayerStatusManager.Life > 0 )
		{
			StartCoroutine( ResurrectionCoroutine() );
		}

	}

	public void Graze( Transform grazeObject )
	{
		var particleGraze = InstantiateAsChild( Trans, prefabParticleGraze );
		particleGraze.transform.position = Vector3.Lerp( grazeObject.position, Trans.position, 0.5f );
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
	private void AutoSpecialMode()
	{
		if( isSpecialMode )	return;
		
		if( !prefabSpecialModeContent.CanExecute() )	return;
		
		isSpecialMode = true;
		PlayerStatusManager.UseSpecialMode( prefabSpecialModeContent.NeedPoint * 2 );
		InstantiateAsChild( cachedTransform, prefabSpecialModeContent.gameObject );
	}
	/// <summary>
	/// 座標を初期値に戻す.
	/// </summary>
	private void Relocation()
	{
		Trans.position = initialPosition;
	}
	/// <summary>
	/// 復活コルーチン処理.
	/// </summary>
	/// <returns>
	/// The coroutine.
	/// </returns>
	private IEnumerator ResurrectionCoroutine()
	{
		int t = 60;
		while( t > 0 )
		{
			yield return new WaitForEndOfFrame();
			t--;
		}

		ReferenceManager.refUILayer.BroadcastMessage( GameDefine.ResurrectionMessage );
		Relocation();
		refContent.SetActive( true );
		SetInvincible( 180 );
	}
	/// <summary>
	/// デバッグ更新処理.
	/// </summary>
	private void UpdateDebug()
	{
		// 無敵デバッグがtrueなら無敵.
		if( DebugManager.IsInvincible )
		{
			SetInvincible( 1 );
		}

		if( DebugManager.IsSpecialPointInfinity )
		{
			ReferenceManager.RefPlayerStatusManager.AddSpecialPoint( PlayerStatusManager.MaxSpecialPoint );
		}
	}
}
