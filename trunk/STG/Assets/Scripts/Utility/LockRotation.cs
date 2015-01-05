/*===========================================================================*/
/*
*     * FileName    : LockRotation.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
public class LockRotation : MonoBehaviour
{
	public Vector3 origin;

	[SerializeField]
	private bool applyX = true;
	
	[SerializeField]
	private bool applyY = true;
	
	[SerializeField]
	private bool applyZ = true;

	[SerializeField]
	private GameDefine.UpdateType updateType = GameDefine.UpdateType.LateUpdaye;

	void Update()
	{
		if( updateType != GameDefine.UpdateType.Update )
		{
			return;
		}

		Lock();
	}
	void LateUpdate()
	{
		if( updateType != GameDefine.UpdateType.LateUpdaye )
		{
			return;
		}
		
		Lock();
	}

	private void Lock()
	{
		var rotation = transform.rotation.eulerAngles;
		float x = applyX ? origin.x : rotation.x;
		float y = applyY ? origin.y : rotation.y;
		float z = applyZ ? origin.z : rotation.z;
		transform.rotation = Quaternion.Euler( x, y, z );
	}
}
