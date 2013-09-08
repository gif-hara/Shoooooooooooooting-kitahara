/*===========================================================================*/
/*
*     * FileName    : EnemyShotSeparateCurve.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyShotSeparateCurve : GameMonoBehaviour
{
	public List<EnemyShotCreateComponentSeparate> targetList;
	
	public EnemyShotCreateComponent.Element element;
	
	public override void Update()
	{
		base.Update();
		targetList.ForEach( (obj) =>
		{
			obj.separate = element.EvaluteFloorToInt();
		});
	}
}
