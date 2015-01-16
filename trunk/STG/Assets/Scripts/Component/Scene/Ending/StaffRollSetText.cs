/*===========================================================================*/
/*
*     * FileName    : StaffRollSetText.cs
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
public class StaffRollSetText : MonoBehaviour
{
	[SerializeField]
	private TextMesh refContent;

	void OnModifyStaffRollData( StaffRollObserver.Data data )
	{
		refContent.text = data.Text;
	}
}
