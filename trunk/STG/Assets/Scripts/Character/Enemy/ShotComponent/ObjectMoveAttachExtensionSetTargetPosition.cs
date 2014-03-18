/*===========================================================================*/
/*
*     * FileName    :ObjectMoveAttachExtensionSetTargetPosition.cs
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
public class ObjectMoveAttachExtensionSetTargetPosition : MonoBehaviour
{
	[SerializeField]
	private Transform refTargetPosition;

	void OnExtensionObjectMoveAttach( GameObject createdObject )
	{
		var list = createdObject.GetComponents<A_ObjectMove>();
		System.Array.ForEach<A_ObjectMove>( list, a =>
		{
			a.data.targetPosition = refTargetPosition.localPosition;
		});
	}
}
