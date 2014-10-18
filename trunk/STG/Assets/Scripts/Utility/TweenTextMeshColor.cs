/*===========================================================================*/
/*
*     * FileName    : TweenTextMeshColor.cs
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
public class TweenTextMeshColor : MonoBehaviour
{
	[SerializeField]
	private TextMesh refTextMesh;
	
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
	
	private int currentDuration;
	
	[ContextMenu( "Attach TextMesh" )]
	void AttachMeshFilter()
	{
		this.refTextMesh = gameObject.GetComponent<TextMesh>();
	}
	
	// Use this for initialization
	void Start ()
	{
		currentDuration = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if( PauseManager.Instance.IsPause )	return;
		
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
		refTextMesh.color = Color.Lerp( from, to, (float)currentDuration / (float)duration );
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
