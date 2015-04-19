/*===========================================================================*/
/*
*     * FileName    : MonoBehaviourEnableSetterOnActiveMuzzle.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class MonoBehaviourEnableSetterOnActiveMuzzle : MonoBehaviour, I_MuzzleEventActinable
{
	[SerializeField]
	private int delay;
	
	[SerializeField]
	private List<MonoBehaviour> refMonoBehaviourList;

	[SerializeField]
	private bool isEnable;

	/// <summary>
	/// 銃口がアクティブになった際のイベント.
	/// </summary>
	public void OnActiveMuzzle()
	{
		FrameRateUtility.StartCoroutine( delay, () =>
		{
			refMonoBehaviourList.ForEach( (obj) =>
			{
				obj.enabled = isEnable;	
			});
		});
	}
}
