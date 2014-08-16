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
	
	private Color toColor = Color.clear;
	
	public override void Start()
	{
		base.Start();
		refMaterial = refRenderer.material;
	}
	
	public override void Update()
	{
		base.Update();
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
		enabled = true;
	}
	
	private void UpdateDuration()
	{
		if( duration >= target )
		{
			SetColor( toColor );
			enabled = false;
			return;
		}
		
		SetColor( Color.Lerp( fromColor, toColor, (float)duration / target ) );
		duration++;
	}

	private void SetColor( Color c )
	{
		refMaterial.SetColor( "_Color", c );
	}
}
