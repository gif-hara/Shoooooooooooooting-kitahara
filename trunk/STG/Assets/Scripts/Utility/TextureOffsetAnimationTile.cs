/*===========================================================================*/
/*
*     * FileName    : TextureOffsetAnimationTile.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class TextureOffsetAnimationTile : MonoBehaviour
{
	/// <summary>
	/// 死亡させるオブジェクト参照.
	/// </summary>
	public GameObject refDestroyObject;
	
	/// <summary>
	/// X分割数.
	/// </summary>
	public int tileX;
	
	/// <summary>
	/// Y分割数.
	/// </summary>
	public int tileY;
	
	/// <summary>
	/// オフセットの更新間隔.
	/// </summary>
	public int interval;
	
	/// <summary>
	/// ループするか.
	/// </summary>
	public bool loop;
	
	/// <summary>
	/// 現在のインターバル.
	/// </summary>
	private int currentInterval = 0;
	
	/// <summary>
	/// オフセットを行った回数.
	/// </summary>
	private int offsetCount = 0;
	
	/// <summary>
	/// マテリアル保持.
	/// </summary>
	private Material myMaterial;
	
	// Use this for initialization
	void Start()
	{
		myMaterial = renderer.material;
		myMaterial.mainTextureScale = new Vector2( 1.0f / tileX, 1.0f / tileY );
		UpdateOffset();
	}

	// Update is called once per frame
	void Update()
	{
		UpdateInterval();
	}
	
	void OnDestroy()
	{
		Destroy( myMaterial );
	}
	/// <summary>
	/// インターバルの更新.
	/// </summary>
	private void UpdateInterval()
	{
		if( currentInterval >= interval )
		{
			UpdateOffset();
			currentInterval = 0;
			offsetCount++;
			return;
		}
		
		currentInterval++;
	}
	/// <summary>
	/// オフセットの更新.
	/// </summary>
	private void UpdateOffset()
	{
		float xOrigin = 1.0f / tileX;
		xOrigin = xOrigin * ( offsetCount % tileX );
		float yOrigin = 1.0f - (1.0f / tileY);
		yOrigin += yOrigin * (offsetCount / tileX);
		myMaterial.mainTextureOffset = new Vector2( xOrigin, yOrigin );
		
		if( offsetCount >= (tileX * tileY) )
		{
			if( loop )
			{
				offsetCount = 0;
			}
			else
			{
				Destroy();
			}
		}
	}
	/// <summary>
	/// 死亡処理.
	/// </summary>
	private void Destroy()
	{
		Destroy( refDestroyObject );
	}
}
