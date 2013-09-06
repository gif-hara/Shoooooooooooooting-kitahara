/*===========================================================================*/
/*
*     * FileName    : LookAtObject.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LookAtObject : MonoBehaviourExtension
{
	public Transform refTarget;
	
	public Vector3 refTargetPosition;
	
	public float lookSpeed;
	
	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		SyncRotationObjectPosition();
		
		if( lookSpeed >= 1.0f )
		{
			Trans.LookAt( refTargetPosition, Vector3.forward );
			Trans.rotation *= Quaternion.AngleAxis( -90.0f, Vector3.right );
		}
		else
		{
			Quaternion tmpRotation = Trans.rotation;
			Trans.LookAt( refTargetPosition, Vector3.forward );
			Trans.rotation *= Quaternion.AngleAxis( -90.0f, Vector3.right );
			Trans.rotation = Quaternion.Lerp( tmpRotation, Trans.rotation, lookSpeed );
		}
		
		if( refTarget != null )
		{
			refTargetPosition = refTarget.position;
		}
	}
	
	private void SyncRotationObjectPosition()
	{
		var pos = Trans.position;
		Trans.position = new Vector3( pos.x, pos.y, refTargetPosition.z );
	}
	
	public static LookAtObject Begin( Transform parent, Transform target, float lookSpeed )
	{
		GameObject obj = new GameObject( "[LookAtObject] Chase-> " + target.name );
		var instance = obj.AddComponent<LookAtObject>();
		obj.transform.parent = parent;
		obj.transform.localPosition = Vector3.zero;
		instance.refTarget = target;
		instance.refTargetPosition = target.position;
		instance.lookSpeed = lookSpeed;
		
		return instance;
	}
	
	public static LookAtObject Begin( Transform parent, Vector3 target, float lookSpeed )
	{
		GameObject obj = new GameObject( "[LookAtObject] Chase-> " + target.ToString() );
		var instance = obj.AddComponent<LookAtObject>();
		obj.transform.parent = parent;
		obj.transform.localPosition = Vector3.zero;
		instance.refTargetPosition = target;
		instance.lookSpeed = lookSpeed;
		
		return instance;
	}
}
