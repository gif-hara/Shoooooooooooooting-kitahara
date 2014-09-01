/*===========================================================================*/
/*
*     * FileName    : TextureFlashFromEnemyHitPoint.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敵のヒットポイントによってテクスチャの色を赤く点滅させるコンポーネント.
/// </summary>
public class TextureFlashFromEnemyHitPoint : GameMonoBehaviour
{
	[SerializeField]
	private EnemyController refEnemy;

	[SerializeField]
	private List<Renderer> refRendererList;

	private int timer = 0;

	private MeshColorManager meshColorManager;

	/// <summary>
	/// 点滅させるために必要な残りヒットポイントのパーセンテージ.
	/// </summary>
	private const int CanUpdatePercent = 10;

	/// <summary>
	/// 通常の色.
	/// </summary>
	private readonly Color NormalColor = Color.white;

	/// <summary>
	/// 瀕死の色.
	/// </summary>
	private readonly Color DyingColor = Color.red;

	private const int FlashInterval = 30;

	[ContextMenu( "All Select Renderer" )]
	public void AllSelect()
	{
		refRendererList = new List<Renderer>();
		refEnemy.Trans.AllVisit( (t) =>
		{
			if( t.GetComponent<MeshRenderer>() != null )
			{
				refRendererList.Add( t.GetComponent<MeshRenderer>() );
			}
		});
	}

	public void SelectEnemy( EnemyController enemy )
	{
		this.refEnemy = enemy;
	}

	public override void Start ()
	{
		this.meshColorManager = new MeshColorManager();
		this.meshColorManager.Initialize( this.refRendererList );
	}
	public override void LateUpdate ()
	{
		if( !IsUpdate )	return;

		if( timer % FlashInterval < 2 )
		{
			this.meshColorManager.SetColor( DyingColor );
		}
		else if( timer % FlashInterval == 2 )
		{
			this.meshColorManager.SetColor( NormalColor );
		}

		timer++;
	}

	private bool IsUpdate
	{
		get
		{
			return ((refEnemy.Hp / refEnemy.MaxHp) * 100.0f) <= CanUpdatePercent;
		}
	}

}
