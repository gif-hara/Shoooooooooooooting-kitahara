/*===========================================================================*/
/*
*     * FileName    : MonoBehaviourEnableSetter.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MonoBehaviourEnableSetter : MonoBehaviour
{
	public List<MonoBehaviour> refTargetList;
	
	public bool isEnable;
	
	public int delay;
	
	// Update is called once per frame
	void Update()
	{
		if( delay <= 0 )
		{
			refTargetList.ForEach( (obj) =>
			{
				obj.enabled = isEnable;	
			});
			enabled = false;
		}
		
		delay--;
	}
}
