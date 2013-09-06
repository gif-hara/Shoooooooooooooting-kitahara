/*===========================================================================*/
/*
*     * FileName    : EnemyFlashController.cs
*
*     * Description : 敵の点滅処理クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyFlashController : EnemyControllerBase
{
	/// <summary>
	/// 敵クラス参照.
	/// </summary>
	public EnemyController refEnemy;
	
	/// <summary>
	/// レンダラ参照リスト.
	/// </summary>
	public List<Renderer> refRendererList;
	
	/// <summary>
	/// マテリアル色変え時間.
	/// </summary>
	private int duration = 0;
	
	/// <summary>
	/// マテリアルリスト.
	/// </summary>
	private List<Material> materialList;
	
	/// <summary>
	/// 現在のマテリアルの色保持.
	/// </summary>
	private Color currentColor = Color.white;
	
	/// <summary>
	/// 通常の色.
	/// </summary>
	private readonly Color NormalColor = Color.white;
	
	/// <summary>
	/// ダメージの色.
	/// </summary>
	private readonly Color DamageColor = Color.yellow;
	
	/// <summary>
	/// 瀕死の色.
	/// </summary>
	private readonly Color DyingColor = Color.red;
	
	/// <summary>
	/// durationに加算する値.
	/// </summary>
	private const int AddDuration = 1;
	
	/// <summary>
	/// ダメージと判断するヒットポイント正規化値.
	/// </summary>
	private const float DamageColorNormalize = 0.1f;
	
	// Use this for initialization
	void Start()
	{
		InitMaterialList();
	}

	// Update is called once per frame
	void LateUpdate()
	{
		UpdateColor();
		duration--;
	}
	
	void OnDestroy()
	{
		if( materialList == null )	return;
		for( int i=0,imax=materialList.Count; i<imax; i++ )
		{
			Destroy( materialList[i] );
		}
		for( int i=0,imax=refRendererList.Count; i<imax; i++ )
		{
			if( refRendererList[i] == null )	continue;
			
			refRendererList[i].enabled = false;
		}
	}
	
	public override void TakeDamage( float damage )
	{
		if( duration > -1 )	return;
		
		duration = AddDuration;
	}
	
	private void InitMaterialList()
	{
		materialList = new List<Material>();
		refRendererList.ForEach( (obj) =>
		{
			materialList.Add( obj.material );
		});
	}
	
	private void UpdateColor()
	{
		var current = GetColor;
		if( currentColor == current )	return;
		
		materialList.ForEach( (obj) =>
		{
			obj.color = current;
		});
		currentColor = current;
	}
	
	private Color GetColor
	{
		get
		{
			if( duration <= 0 )
			{
				return NormalColor;
			}
			else if( refEnemy.CurrentHitPointNormalize >= DamageColorNormalize )
			{
				return DamageColor;
			}
			
			return DyingColor;
		}
	}
}
