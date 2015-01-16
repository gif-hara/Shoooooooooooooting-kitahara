/*===========================================================================*/
/*
*     * FileName    : StaffRollSetObjectMoveTweenPosition.cs
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
public class StaffRollSetObjectMoveTweenPosition : MonoBehaviour
{
	[SerializeField]
	private ObjectMoveTween refContent;

	[SerializeField]
	private Vector3 origin;

	[SerializeField]
	private Vector3 interval;

	void OnModifyStaffRollData( StaffRollObserver.Data data )
	{
		refContent.data.targetPosition = origin + interval * data.ID;
	}
}
