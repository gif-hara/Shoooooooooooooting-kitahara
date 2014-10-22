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
	
	// Use this for initialization
	void Start()
	{
	}

	void LateUpdate()
	{
		var rotation = transform.rotation.eulerAngles;
		float x = applyX ? origin.x : rotation.x;
		float y = applyY ? origin.y : rotation.y;
		float z = applyZ ? origin.z : rotation.z;
		transform.rotation = Quaternion.Euler( x, y, z );
	}
}
