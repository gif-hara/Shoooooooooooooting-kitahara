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


public class RendererEnableSetter : MonoBehaviour
{
	/// <summary>
	/// enableの設定をするターゲット.
	/// </summary>
	public List<Renderer> refTargetList;
	
	/// <summary>
	/// 表示するか.
	/// </summary>
	public bool isVisible;
	
	/// <summary>
	/// 遅延時間.
	/// </summary>
	public int delay;
	
	// Update is called once per frame
	void Update()
	{
		if( delay <= 0 )
		{
			refTargetList.ForEach( (obj) =>
			{
				obj.enabled = isVisible;
			});
			enabled = false;
		}
		
		delay--;
	}
}
