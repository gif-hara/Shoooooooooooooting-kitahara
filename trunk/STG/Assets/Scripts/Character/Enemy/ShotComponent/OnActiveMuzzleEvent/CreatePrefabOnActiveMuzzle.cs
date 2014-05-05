/*===========================================================================*/
/*
*     * FileName    : CreatePrefabOnActiveMuzzle.cs
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
public class CreatePrefabOnActiveMuzzle : GameMonoBehaviour, I_MuzzleEventActinable
{
	[SerializeField]
	private int delay;

	[SerializeField]
	private Transform refParent;

	[SerializeField]
	private GameObject prefab;

	/// <summary>
	/// 銃口がアクティブになった際のイベント.
	/// </summary>
	public void OnActiveMuzzle()
	{
		FrameRateUtility.StartCoroutine( delay, () =>
		{
			var obj = InstantiateAsChild( refParent, prefab );
			obj.transform.localPosition = Vector3.zero;
		});
	}
}
