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
	void Start()
	{
		refLookAtObject = LookAtObject.Begin( Trans, ReferenceManager.refPlayer.transform, lookSpeed );
	}

	// Update is called once per frame
	void Update()
	{
		Trans.rotation = refLookAtObject.Trans.rotation;
	}
}
