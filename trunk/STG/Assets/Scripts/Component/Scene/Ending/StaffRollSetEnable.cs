/*===========================================================================*/
/*
*     * FileName    : StaffRollSetEnable.cs
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
public class StaffRollSetEnable : MonoBehaviour
{
	[SerializeField]
	private GameObject refContent;

	[SerializeField]
	private int delay;

	void OnModifyStaffRollData( StaffRollObserver.Data data )
	{
		refContent.SetActive( false );
		FrameRateUtility.StartCoroutine( delay * data.ID, () => refContent.SetActive( true ) );
	}
}
