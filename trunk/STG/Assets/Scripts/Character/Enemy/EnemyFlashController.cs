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
	private List<Mesh> meshList;
	
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
	public override void Start()
	{
		base.Start();
		InitMeshList();
	}

	// Update is called once per frame
	public override void LateUpdate()
	{
		base.LateUpdate();
		UpdateColor();
		duration--;
	}
	
	void OnDestroy()
	{
		if( meshList == null )	return;
		for( int i=0,imax=meshList.Count; i<imax; i++ )
		{
			Destroy( meshList[i] );
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
	
	private void InitMeshList()
	{
		meshList = new List<Mesh>();
		refRendererList.ForEach( (obj) =>
		{
			meshList.Add( obj.GetComponent<MeshFilter>().mesh );
		});
	}
	
	private void UpdateColor()
	{
		var current = GetColor;
		if( currentColor == current )	return;
		
		meshList.ForEach( (obj) =>
		{
			Color[] colors = new Color[obj.colors.Length];
			for( int i=0,imax=colors.Length; i<imax; i++ )
			{
				colors[i] = current;
			}
			obj.colors = colors;
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
