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

	private bool endCountUp = false;

	public override void Start ()
	{
		Next();
	}

	public override void Update ()
	{
		if( !endCountUp )	return;

		if( !Input.GetKeyDown( KeyCode.Z ) )	return;

		refCountUpObjectList.ForEach( c =>
		                             {
			c.GetComponent<ResultUICountUpController>().EndEffect();
		});
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
		endCountUp = true;
	}
}
