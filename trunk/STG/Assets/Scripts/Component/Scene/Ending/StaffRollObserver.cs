/*===========================================================================*/
/*
*     * FileName    : StaffRollObserver.cs
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
public class StaffRollObserver : MonoBehaviour
{
	public const string Message = "OnModifyStaffRollData";

	public class Data
	{
		public string Text{ private set; get; }
		
		public int ID{ private set; get; }
		
		public Data( string text, int id )
		{
			this.Text = text;
			this.ID = id;
		}
	}

	public Data Content
	{
		set
		{
			gameObject.BroadcastMessage( Message, value );
		}
	}
}
