//================================================
/*!
    @file   DamageEventTextureFlash.cs

    @brief  ダメージ時にテクスチャをフラッシュさせるコンポーネント.

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ダメージ時にテクスチャをフラッシュさせるコンポーネント.
/// </summary>
public class DamageEventTextureFlash : GameMonoBehaviour, I_DamageEvent
{
	/// <summary>
	/// 敵クラス参照.
	/// </summary>
	[SerializeField]
	private EnemyController refEnemy;
	
	/// <summary>
	/// レンダラ参照リスト.
	/// </summary>
	[SerializeField]
	private List<Renderer> refRendererList;
	
	/// <summary>
	/// マテリアル色変え時間.
	/// </summary>
	private int duration = 0;
	
	/// <summary>
	/// メッシュ管理者.
	/// </summary>
	private MeshColorManager meshManager;
	
	/// <summary>
	/// 通常の色.
	/// </summary>
	private readonly Color NormalColor = Color.white;
	
	/// <summary>
	/// ダメージの色.
	/// </summary>
	private readonly Color DamageColor = new Color( 238.0f / 255.0f, 230.0f / 255.0f, 124.0f / 255.0f );
	
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

	[ContextMenu( "All Select Renderer" )]
	void AllSelect()
	{
		refRendererList.Clear();
		refEnemy.Trans.AllVisit( (t) =>
		{
			if( t.renderer != null )
			{
				refRendererList.Add( t.renderer );
			}
		});
	}

	// Use this for initialization
	public override void Start()
	{
		base.Start();
		meshManager = new MeshColorManager();
		meshManager.Initialize( refRendererList );
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
		for( int i=0,imax=refRendererList.Count; i<imax; i++ )
		{
			if( refRendererList[i] == null )	continue;
			
			refRendererList[i].enabled = false;
		}
	}
	/// <summary>
	/// ダメージ処理.
	/// </summary>
	/// <param name="damage">Damage.</param>
	public void OnDamage( float damage )
	{
		if( duration > -1 )	return;
		
		duration = AddDuration;
	}
	
	private void UpdateColor()
	{
		var current = GetColor;
		meshManager.SetColor( current );
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
