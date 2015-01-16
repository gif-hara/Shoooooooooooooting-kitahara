/*===========================================================================*/
/*
*     * FileName    : CreateStaffRoll.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class CreateStaffRoll : MonoBehaviour
{
	[SerializeField]
	private GameObject prefabStaffRollText;

	[SerializeField]
	private int originDelay;

	[SerializeField]
	private int interval;

	[SerializeField]
	private GameObject refEndObject;

	[SerializeField]
	private List<Data> staffRollList;

	private int delay = 0;

	private int createId = 0;

	[System.Serializable]
	public class Data
	{
		public List<string> TextList{ get{ return textList; } }
		[SerializeField]
		private List<string> textList;
	}
	
	// Use this for initialization
	void Start ()
	{
		Create();
	}

	void Update()
	{
		if( delay >= 0 )
		{
			delay--;
			return;
		}

		if( createId < staffRollList.Count )
		{
			Create();
		}
		else
		{
			refEndObject.SetActive( true );
			enabled = false;
		}
	}

	private void Create()
	{
		for( int i=0,imax=staffRollList[createId].TextList.Count; i<imax; i++ )
		{
			var staffRollObserver = GameMonoBehaviour.InstantiateAsChild( transform, prefabStaffRollText ).GetComponent<StaffRollObserver>();
			staffRollObserver.Content = new StaffRollObserver.Data( staffRollList[createId].TextList[i], i );
		}
		delay = originDelay + staffRollList[createId].TextList.Count * interval;
		createId++;
	}
}
