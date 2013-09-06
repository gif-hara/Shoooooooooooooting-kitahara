/*===========================================================================*/
/*
*     * FileName    : FadeManager.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FadeManager : GameMonoBehaviour
{
	public Renderer refRenderer;
	
	private Material refMaterial;
	
	private int duration = 0;
	
	private int target = 0;
	
	private Color fromColor = Color.white;
	
	private Color toColor = Color.white;
	
	void Start()
	{
		refMaterial = refRenderer.material;
	}
	
	void Update()
	{
		int id = ScriptProfiler.Begin( this );
		UpdateDuration();
		ScriptProfiler.End( this, id );
	}
	
	public void Begin( Color _from, Color _to, int target )
	{
		this.fromColor = _from;
		this.toColor = _to;
		this.target = target;
		this.duration = 0;
	}
	
	private void UpdateDuration()
	{
		if( duration >= target )	return;
		
		refMaterial.SetColor( "_Color", Color.Lerp( fromColor, toColor, (float)duration / target ) );
		duration++;
	}
}
