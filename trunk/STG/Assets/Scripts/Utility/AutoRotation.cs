/*===========================================================================*/
/*
*     * FileName    : AutoRotation.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class AutoRotation : MonoBehaviour
{
	public float speed;
	
	public Vector3 axis;
	
	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		transform.localRotation *= Quaternion.AngleAxis( speed, axis );
	}

}
