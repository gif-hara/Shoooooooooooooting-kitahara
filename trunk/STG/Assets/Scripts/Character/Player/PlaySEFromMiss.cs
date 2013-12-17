/*===========================================================================*/
/*
*     * FileName    : PlaySEFromMiss.cs
*
*     * Description : ゲーム管理者クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

public class PlaySEFromMiss : MonoBehaviour, I_MissEvent
{
	/// <summary>
	/// ラベル.
	/// </summary>
	[SerializeField]
	private string label;

	public void OnMiss()
	{
		ReferenceManager.Instance.refSoundManager.Play( label );
	}
}
