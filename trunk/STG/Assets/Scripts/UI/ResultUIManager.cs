/*===========================================================================*/
/*
*     * FileName    : ResultUIManager.cs
*
*     * Description : リザルトUI管理者クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// リザルトUI管理者クラス.
/// </summary>
public class ResultUIManager : GameMonoBehaviour
{
	[SerializeField]
	private List<GameObject> refCountUpObjectList;

	private int currentCountUpNum = 0;

	public override void Start ()
	{
		Next();
	}

	public void Next()
	{
		if( refCountUpObjectList.Count == currentCountUpNum )
		{
			End();
		}
		else
		{
			NextCountUp();
		}
	}

	private void NextCountUp()
	{
		refCountUpObjectList[currentCountUpNum].SetActive( true );
		currentCountUpNum++;
	}

	private void End()
	{

	}
}
