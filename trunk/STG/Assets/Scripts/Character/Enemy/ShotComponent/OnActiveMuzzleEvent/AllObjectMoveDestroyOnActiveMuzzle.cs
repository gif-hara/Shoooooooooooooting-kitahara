/*===========================================================================*/
/*
*     * FileName    : AllObjectMoveDestroyOnActiveMuzzle.cs
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
public class AllObjectMoveDestroyOnActiveMuzzle : GameMonoBehaviour, I_MuzzleEventActinable
{
	[SerializeField]
	private GameObject refParent;

	/// <summary>
	/// 銃口がアクティブになった際のイベント.
	/// </summary>
	public void OnActiveMuzzle()
	{
		ObjectMoveUtility.AllDetach( refParent );
	}
}
