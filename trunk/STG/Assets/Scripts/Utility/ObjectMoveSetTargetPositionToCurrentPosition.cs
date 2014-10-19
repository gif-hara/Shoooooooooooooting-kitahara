/*===========================================================================*/
/*
*     * FileName    : ObjectMoveSetTargetPositionToCurrentPosition.cs
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
public class ObjectMoveSetTargetPositionToCurrentPosition : MonoBehaviour
{
	[SerializeField]
	private A_ObjectMove refObjectMove;

	void Start()
	{
		refObjectMove.data.targetPosition = transform.position;
	}
}
