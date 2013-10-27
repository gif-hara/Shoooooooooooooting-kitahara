/*===========================================================================*/
/*
*     * FileName    : GameObjectEnableSetter.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameObjectEnableSetter : A_DelayEvent
{
	public List<GameObject> refTargetList;
	
	public bool isEnable;
	
	protected override void OnDelayEvent()
	{
		refTargetList.ForEach( (obj) =>
		{
			obj.SetActive( isEnable );
		});
	}
}
