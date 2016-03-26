/*===========================================================================*/
/*
*     * FileName    : TextureOffsetAnimation.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TextureOffsetAnimation : MonoBehaviour
{
	public float xSpeed;
	
	public float ySpeed;
	
	public Transform refContent;
	
	public Vector2 size;

	[SerializeField]
	private bool isPauseActive;
	
	private Material myMaterial = null;
	
	private int currentInterval = 0;
	
	// Use this for initialization
	void Start()
	{
		myMaterial = GetComponent<Renderer>().material;
	}

	// Update is called once per frame
	void Update()
	{
		if( !isPauseActive && PauseManager.Instance.IsPause )	return;
		
		UpdateOffset();
		UpdateScale();
		currentInterval++;
	}
	
	private void UpdateOffset()
	{
		float frame = (float)currentInterval / Application.targetFrameRate;
		myMaterial.mainTextureOffset = new Vector2( xSpeed * frame, ySpeed * frame );
	}
	
	private void UpdateScale()
	{
		float normalize = refContent.localScale.x / size.x;
		myMaterial.mainTextureScale = new Vector2( normalize, myMaterial.mainTextureScale.y );
	}
}
