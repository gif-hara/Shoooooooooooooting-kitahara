/*===========================================================================*/
/*
*     * FileName    : RendererEnableSetter.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RendererEnableSetter : A_DelayEvent
{
	/// <summary>
	/// enableの設定をするターゲット.
	/// </summary>
	public List<Renderer> refTargetList;
	
	/// <summary>
	/// 表示するか.
	/// </summary>
	public bool isVisible;
	
	protected override void OnDelayEvent()
	{
		refTargetList.ForEach( (obj) =>
		{
			obj.enabled = isVisible;
		});
	}
}
