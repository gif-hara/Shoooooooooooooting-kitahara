/*===========================================================================*/
/*
*     * FileName    : MonoBehaviourEnableSetterFromExtraStageNextProgress.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class MonoBehaviourEnableSetterFromExtraStageNextProgress : MonoBehaviour
{
	public List<MonoBehaviour> refTargetList;
	
	public bool isEnable;
	
	void OnExtraStageNextProgress()
	{
		refTargetList.ForEach( (obj) =>
		                      {
			obj.enabled = isEnable;	
		});
	}
}
