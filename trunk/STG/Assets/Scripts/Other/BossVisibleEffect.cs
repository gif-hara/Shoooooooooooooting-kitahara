/*===========================================================================*/
/*
*     * FileName    : BossVisibleEffect.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BossVisibleEffect : GameMonoBehaviour
{
	/// <summary>
	/// フェードオブジェクト参照.
	/// </summary>
	public Renderer refFade;
	
	/// <summary>
	/// 左側ラインエフェクト参照.
	/// </summary>
	public List<TweenPosition> refLeftLineEffect;
	
	/// <summary>
	/// 右側ラインオブジェクト参照.
	/// </summary>
	public List<TweenPosition> refRightLineEffect;
	
	/// <summary>
	/// [WARNING]画像参照.
	/// </summary>
	public Renderer refWarning;
	
	/// <summary>
	/// [WARNING]画像開始演出時間.
	/// </summary>
	public int warningStartTime;
	
	public int warningUpdateSinRate;
	
	public int warningEndTime;
	
	/// <summary>
	/// 総合タイマー.
	/// </summary>
	private int totalTimer = 0;
	
	private int warningTimer = 0;
	
	/// <summary>
	/// 再生したSEの回数.
	/// </summary>
	private int playSENum = 0;
	
	/// <summary>
	/// ラインエフェクトの非表示演出処理を行ったか.
	/// </summary>
	private bool isLineInvisible = false;
	
	/// <summary>
	/// [WARNING]画像の更新関数.
	/// </summary>
	private System.Action warningTextureUpdateFunc = null;
	
	/// <summary>
	/// 演出最大タイム.
	/// </summary>
	private const int maxTimer = 500;
	
	/// <summary>
	/// SEを鳴らす最大値.
	/// </summary>
	private const int maxPlaySENum = 4;
	
	/// <summary>
	/// ラインエフェクト表示位置.
	/// </summary>
	private const float LineEffectVisiblePositionX = 310.0f;
	
	/// <summary>
	/// ラインエフェクト非表示位置.
	/// </summary>
	private const float LineEffectInvisiblePositionX = 1100.0f;
	
	private readonly Color WarningInvisibleColor = new Color( 1.0f, 1.0f, 1.0f, 0.0f );
	
	private readonly Color WarningUpdateFromColor = new Color( 1.0f, 1.0f, 1.0f, 0.4f );
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		InitWarningRenderer();
	}
	
	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		UpdateFade();
		UpdateLineEffect();
		UpdatePlaySE();
		warningTextureUpdateFunc();
		
		totalTimer++;
	}
	
	private void InitWarningRenderer()
	{
		refWarning.sharedMaterial.SetColor( "_Color", WarningInvisibleColor );
		warningTextureUpdateFunc = UpdateWarning_Start;
	}
	/// <summary>
	/// フェードの更新処理.
	/// </summary>
	private void UpdateFade()
	{
		refFade.material.SetColor( "_Color", Shader_Color );
		refFade.material.SetColor( "_ColorAlpha", Shader_ColorAlpha );
	}
	/// <summary>
	/// 線エフェクトの更新処理.
	/// </summary>
	private void UpdateLineEffect()
	{
		if( isLineInvisible )	return;
		
		if( playSENum >= 4 )
		{
			isLineInvisible = true;
			refLeftLineEffect.ForEach( (obj) =>
			{
				var leftLinePos = obj.transform.position;
				TweenPosition.Begin( obj.gameObject, 1.0f, new Vector3( -LineEffectInvisiblePositionX, leftLinePos.y, leftLinePos.z ) );
			});
			refRightLineEffect.ForEach( (obj) =>
			{
				var rightLinePos = obj.transform.position;
				TweenPosition.Begin( obj.gameObject, 1.0f, new Vector3( LineEffectInvisiblePositionX, rightLinePos.y, rightLinePos.z ) );
			});
		}
	}
	/// <summary>
	/// SEの再生更新処理.
	/// </summary>
	private void UpdatePlaySE()
	{
		if( playSENum >= maxPlaySENum )	return;
		
		if( totalTimer % ( maxTimer / maxPlaySENum ) == 0 )
		{
			ReferenceManager.refSoundManager.Play( "Warning" );
			playSENum++;
		}
	}
	
	private void UpdateWarning_Start()
	{
		if( warningTimer > warningStartTime )
		{
			warningTimer = 0;
			warningTextureUpdateFunc = UpdateWarning_Update;
		}
		
		refWarning.sharedMaterial.SetColor( "_Color", Warning_StartColor );
		
		warningTimer++;
	}
	
	private void UpdateWarning_Update()
	{
		if( playSENum >= 4 )
		{
			warningTextureUpdateFunc = UpdateWarning_End;
			warningTimer = 0;
			return;
		}
		
		refWarning.sharedMaterial.SetColor( "_Color", Warning_UpdateColor );
		warningTimer++;
	}
	
	private void UpdateWarning_End()
	{
		if( warningTimer > warningEndTime )
		{
			Destroy( gameObject );
		}
		
		refWarning.sharedMaterial.SetColor( "_Color", Warning_EndColor );
		warningTimer++;
	}
	
	private Color Warning_StartColor
	{
		get
		{
			return Color.Lerp( WarningInvisibleColor, Color.white, (float)warningTimer / warningStartTime );
		}
	}
	private Color Warning_UpdateColor
	{
		get
		{
			float t = Mathf.Abs( Mathf.Sin( (float)warningTimer / warningUpdateSinRate ) );
			return Color.Lerp( Color.white, WarningUpdateFromColor, 1.0f - t );
		}
	}
	private Color Warning_EndColor
	{
		get
		{
			return Color.Lerp( Color.white, WarningInvisibleColor, (float)warningTimer / warningEndTime );
		}
	}
	
	private Color Shader_Color
	{
		get
		{
			var color = Color.red;
			color.a = Mathf.Abs( Mathf.Sin( totalTimer / 40.0f ) );
			
			return color;
		}
	}
	private Color Shader_ColorAlpha
	{
		get
		{
			var color = Shader_Color;
			color.a /= 5.0f;
			
			return color;
		}
	}
	
}
