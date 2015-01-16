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


public class FadeManager : A_Singleton<FadeManager>
{
	public Renderer refRenderer;
	
	private Material refMaterial;
	
	private int duration = 0;
	
	private int target = 0;
	
	private Color fromColor = Color.white;
	
	private Color toColor = Color.clear;

	private bool ignorePause = false;

	public override void Awake()
	{
		Instance = this;
	}

	public override void Start()
	{
		refMaterial = refRenderer.material;
	}
	
	public override void Update()
	{
		if( !ignorePause && PauseManager.Instance.IsPause )	return;
		
		UpdateDuration();
	}
	
	public void Begin( Color _from, Color _to, int target, bool ignorePause = false, string layerMaskName = "EffectLv4" )
	{
		this.fromColor = _from;
		this.toColor = _to;
		this.target = target;
		this.duration = 0;
		this.ignorePause = ignorePause;
		this.refRenderer.gameObject.layer = LayerMask.NameToLayer( layerMaskName );
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
