/*===========================================================================*/
/*
*     * FileName    : Background.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Background : GameMonoBehaviour
{
	public Renderer refRenderer;
	
	public float speed;
	
	private Material refMaterial;
	
	private int offsetCount = 0;
	
	// Use this for initialization
	void Start()
	{
		refMaterial = refRenderer.sharedMaterial;
	}

	// Update is called once per frame
	void Update()
	{
		refMaterial.mainTextureOffset = new Vector2( 0, (float)(-offsetCount * speed) / 60.0f );
		offsetCount++;
	}

}
