/*===========================================================================*/
/*
*     * FileName    : TweenTextureScale.cs
*
*     * Description : テクスチャのスケール値ツイーン処理.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// テクスチャのスケール値ツイーン処理.
/// </summary>
public class TweenTextureScale : MonoBehaviour
{
	public int duration;

	public AnimationCurve curve;

	public Vector3 from;

	public Vector3 to;

	private Material refMaterial;

	private Transform trans;

	private int currentDuration = 0;

	void Start ()
	{
		refMaterial = GetComponent<Renderer>().material;
		trans = transform;
	}
	
	void Update ()
	{
		UpdateTexture();
		UpdateScale();

		if( currentDuration >= duration )
		{
			enabled = false;
		}

		currentDuration++;
	}

	private void UpdateScale()
	{
		trans.localScale = Vector3.Lerp( from, to, curve.Evaluate( (float)currentDuration / (float)duration ) );
	}

	private void UpdateTexture()
	{
		var offset = refMaterial.mainTextureOffset;
		offset.y = 1.0f - (transform.localScale.y / to.y);
		refMaterial.mainTextureOffset = offset;
		
		var tiling = refMaterial.mainTextureScale;
		tiling.y = (transform.localScale.y / to.y);
		refMaterial.mainTextureScale = tiling;
	}
}
