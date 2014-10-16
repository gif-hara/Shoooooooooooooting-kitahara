/*===========================================================================*/
/*
*     * FileName    : InputChangeChaseGameObject.cs
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
public class InputChangeChaseGameObject : MonoBehaviour
{
	[SerializeField]
	private ChaseGameObject refChaseGameObject;

	[SerializeField]
	private Transform refNormalChaseObject;

	[SerializeField]
	private Transform refShiftChaseObject;

	void Update ()
	{
		InputShift();
	}

	private void InputShift()
	{
		if( Input.GetKey( KeyCode.LeftShift ) )
		{
			refChaseGameObject.refChaseObject = refShiftChaseObject;
		}
		else
		{
			refChaseGameObject.refChaseObject = refNormalChaseObject;
		}
	}
}
