//================================================
/*!
    @file   TweenMeshColor.cs

    @brief  .

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class TweenMeshColor : MonoBehaviour, I_Poolable
{
	[SerializeField]
	private MeshFilter refMeshFIlter;

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

	private int cachedDelay;

	[ContextMenu( "Attach MeshFilter" )]
	void AttachMeshFilter()
	{
		this.refMeshFIlter = gameObject.GetComponent<MeshFilter>();
	}

	void Start()
	{
		meshManager = new MeshColorManager();
		meshManager.Initialize( refMeshFIlter );
		meshManager.SetColor( from );
		this.SetColorImmediate();
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
		meshManager.SetColor( Color.Lerp( from, to, (float)currentDuration / (float)duration ) );
		currentDuration++;
	}

	public void OnAwakeByPool( bool used )
	{
		currentDuration = 0;
		this.enabled = true;

		if( !used )
		{
			this.cachedDelay = this.delay;
		}
		else
		{
			this.delay = this.cachedDelay;
			this.SetColorImmediate();
		}
	}

	public void OnReleaseByPool()
	{

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

	private void SetColorImmediate()
	{
		if( this.delay > 0 )
		{
			return;
		}

		meshManager.SetColor( Color.Lerp( from, to, (float)currentDuration / (float)duration ) );
	}
}
