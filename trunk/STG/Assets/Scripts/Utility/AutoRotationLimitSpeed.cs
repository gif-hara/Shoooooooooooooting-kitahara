/*===========================================================================*/
/*
*     * FileName    : AutoRotationLimitSpeed.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// .
/// </summary>
public class AutoRotationLimitSpeed : MonoBehaviour
{
	[SerializeField]
	private AutoRotation refTarget;

	[SerializeField]
	private float limit;

	// Update is called once per frame
	void Update ()
	{
		if( limit > 0 )
		{
			refTarget.speed = refTarget.speed > limit ? limit : refTarget.speed;
		}
		else
		{
			refTarget.speed = refTarget.speed < limit ? limit : refTarget.speed;
		}
	}
}
