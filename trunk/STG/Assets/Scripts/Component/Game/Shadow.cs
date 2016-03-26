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
	[SerializeField]
	private Renderer refRenderer;

	private Transform chaseObject = null;

	private Renderer chaseObjectRenderer = null;

	[SerializeField]
	private Vector3 offset;

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

		this.refRenderer.enabled = chaseObject.gameObject.activeInHierarchy && chaseObjectRenderer.enabled;
		SyncPosition();
		SyncScale();
		SyncRotation();
	}

	public void Initialize( Transform chaseObject, Vector2 offset, Material material )
	{
		gameObject.name = material.name + " -> Shadow";
		this.chaseObject = chaseObject;
		this.chaseObjectRenderer = chaseObject.GetComponent<MeshRenderer>();
		this.offset = offset;
		this.initScale = chaseObject.localScale;
		Trans.localScale = this.initScale;
		GetComponent<Renderer>().sharedMaterial = material;
		var destroyOnReferenceNull = gameObject.AddComponent<DestroyOnNullReference>();
		destroyOnReferenceNull.refTarget = chaseObject.gameObject;
		destroyOnReferenceNull.refDestroyObject = Trans.gameObject;
	}

	private void SyncPosition()
	{
		Trans.localPosition = this.chaseObject.position + this.offset + shadowManager.Offset;
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
