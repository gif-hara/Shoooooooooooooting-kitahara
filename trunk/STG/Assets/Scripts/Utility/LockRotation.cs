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


public class LockRotation : MonoBehaviour
{
	public Vector3 origin;
	
	// Use this for initialization
	void Start()
	{
	}

	void Update()
	{
		transform.rotation = Quaternion.Euler( origin );
	}
}
