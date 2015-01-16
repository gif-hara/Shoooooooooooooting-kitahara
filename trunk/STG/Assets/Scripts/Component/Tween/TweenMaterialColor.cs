/*===========================================================================*/
/*
*     * FileName    : TweenMaterialColor.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class TweenMaterialColor : MonoBehaviour
{
	[SerializeField]
	private Renderer refRenderer;

	[SerializeField]
	private string colorName;
	
	[SerializeField]
	private int delay;
	
	[SerializeField]
	private int duration;
	
	[SerializeField]
	private Color from = Color.white;
	
	[SerializeField]
	private Color to = Color.white;
	
	[SerializeField]
	private GameObject refCompleteEventReceiver;
	
	[SerializeField]
	private string completeFunctionName;
	
	private MeshColorManager meshManager;
	
	private int currentDuration;

	// Use this for initialization
	void Start ()
	{
		currentDuration = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if( delay > 0 )
		{
			delay--;
			return;
		}
		if( currentDuration > duration )
		{
			enabled = false;
			if( refCompleteEventReceiver != null )
			{
				refCompleteEventReceiver.SendMessage( completeFunctionName );
			}
			
			return;
		}
		refRenderer.material.SetColor( colorName, Color.Lerp( from, to, currentDuration / (float)duration ) );
		currentDuration++;
	}
	
	public void SetDelay( int value )
	{
		this.delay = value;
	}
	
	public void Begin()
	{
		enabled = true;
		currentDuration = 0;
	}
}
