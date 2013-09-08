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
	/// スペシャルポイントの状態定義.
	/// </summary>
	public enum SpecialPointState : int
	{
		Charge,
		Use,
	}
	
	/// <summary>
	/// コンテンツオブジェクト参照.
	/// </summary>
	public GameObject refContent;
	
	/// <summary>
	/// レンダラーリスト.
	/// </summary>
	public List<Renderer> refRenderer;
	
	/// <summary>
	/// スペシャルポイント最大値.
	/// </summary>
	public int maxSpecialPoint;
	
	/// <summary>
	/// バリア発動可能に必要な値.
	/// </summary>
	public int canSpecialPoint;
	
	/// <summary>
	/// バリアポイント加算値.
	/// </summary>
	public int addSpecialPoint;
	
	/// <summary>
	/// バリアポイント最大時のバリアの大きさ.
	/// </summary>
	public float barrierSize;
	
	/// <summary>
	/// バリアサイズのアニメーションカーブ.
	/// </summary>
	public AnimationCurve barrierSizeCurve;
	
	/// <summary>
	/// 現在のバリアポイント.
	/// </summary>
	public int CurrentSpecialPoint{ get{ return currentSpecialPoint; } }
	private int currentSpecialPoint = 0;
	
	/// <summary>
	/// バリア更新処理タイプ.
	/// </summary>
	private SpecialPointState barrierUpdateType = SpecialPointState.Charge;
	
	/// <summary>
	/// 無敵時間.
	/// </summary>
	private int invincibleTime = 0;
	
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
		UpdateBarrierPoint();
		UpdateRenderer();
		invincibleTime--;
		
		UpdateDebug();
	}
	
	public void BarrierExecute()
	{
		currentSpecialPoint -= canSpecialPoint;
		barrierUpdateType = SpecialPointState.Use;
	}
	public void EndBarrier()
	{
		barrierUpdateType = SpecialPointState.Charge;
	}
	
	public void Miss()
	{
		if( IsInvincible )	return;
		
		GameManager.Miss();
		
		refContent.SetActive( false );
		if( GameManager.Life > 0 )
		{
			StartCoroutine( ResurrectionCoroutine() );
		}
	}
	
	public bool IsBarrierExecute
	{
		get
		{
			return currentSpecialPoint >= canSpecialPoint;
		}
	}
	
	public float BarrierPointNormalize
	{
		get
		{
			return (float)currentSpecialPoint / maxSpecialPoint;
		}
	}
	
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
			if( barrierUpdateType == SpecialPointState.Use )
			{
				return true;
			}
			
			return false;
		}
	}
	
	public float CurrentBarrierSize
	{
		get
		{
			return barrierSizeCurve.Evaluate( BarrierPointNormalize ) * barrierSize;
		}
	}
	
	private void Relocation()
	{
		Trans.position = initialPosition;
	}
	/// <summary>
	/// バリアポイント更新処理.
	/// </summary>
	private void UpdateBarrierPoint()
	{
		if( barrierUpdateType == SpecialPointState.Charge )
		{
			currentSpecialPoint += addSpecialPoint;
			currentSpecialPoint = currentSpecialPoint > maxSpecialPoint ? maxSpecialPoint : currentSpecialPoint;
		}
		else
		{
			if( currentSpecialPoint <= 0 )
			{
				invincibleTime = 60;
				EndBarrier();
				return;
			}
			currentSpecialPoint--;
			currentSpecialPoint = currentSpecialPoint < 0 ? 0 : currentSpecialPoint;
		}
		
		// デバッグが有効なら常に最大値にする.
		if( DebugManager.IsSpecialPointInfinity )
		{
			currentSpecialPoint = maxSpecialPoint;
		}
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
		invincibleTime = 240;
		
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
