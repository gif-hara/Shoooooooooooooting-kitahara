/*===========================================================================*/
/*
*     * FileName    : PlayerLookAt.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class PlayerLookAt : GameMonoBehaviour
{
	public float lookSpeed;
	
	private LookAtObject refLookAtObject;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		refLookAtObject = LookAtObject.Begin( Trans, ReferenceManager.refPlayer.transform, lookSpeed );
	}

	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		Trans.rotation = refLookAtObject.Trans.rotation;
	}
}
