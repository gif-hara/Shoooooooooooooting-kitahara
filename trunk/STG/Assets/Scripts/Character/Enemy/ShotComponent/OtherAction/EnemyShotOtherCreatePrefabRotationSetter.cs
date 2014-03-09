/*===========================================================================*/
/*
*     * FileName    :EnemyShotOtherCreatePrefabRotationSetter.cs
*
*     * Description : .
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
public class EnemyShotOtherCreatePrefabRotationSetter : MonoBehaviour
{
	[SerializeField]
	private Vector3 rotate;

	public void OtherCreatePrefabExtension( GameObject obj )
	{
		obj.transform.rotation = Quaternion.Euler( rotate );
	}
}
