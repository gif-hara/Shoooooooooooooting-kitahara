/*===========================================================================*/
/*
*     * FileName    : Shadow.cs
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
public class Shadow : GameMonoBehaviour
{
	private Transform chaseObject = null;

	private Vector3 initScale;

	private static ShadowManager shadowManager = null;
	
	public override void Start ()
	{
		base.Start ();
		InitShadowManager();
	}

	public override void LateUpdate ()
	{
		if( this.chaseObject == null )
		{
			return;
		}

		base.LateUpdate ();

		SyncPosition();
		SyncScale();
		SyncRotation();
	}

	public void Initialize( Transform chaseObject, Material material )
	{
		this.chaseObject = chaseObject;
		this.initScale = chaseObject.localScale;
		Trans.localScale = this.initScale;
		renderer.sharedMaterial = material;
		var destroyOnReferenceNull = gameObject.AddComponent<DestroyOnReferenceNull>();
		destroyOnReferenceNull.refTarget = chaseObject.gameObject;
		destroyOnReferenceNull.refDestroyObject = Trans.gameObject;
	}

	private void SyncPosition()
	{
		Trans.localPosition = this.chaseObject.position + shadowManager.Offset;
	}

	private void SyncScale()
	{
		var scale = initScale;
		scale.x *= shadowManager.Scale.x;
		scale.y *= shadowManager.Scale.y;
		scale.z *= shadowManager.Scale.z;
		Trans.localScale = scale;
	}

	private void SyncRotation()
	{
		Trans.localRotation = chaseObject.rotation;
	}
	
	private void InitShadowManager()
	{
		if( shadowManager == null )
		{
			shadowManager = ReferenceManager.ShadowManager;
		}
	}
}
