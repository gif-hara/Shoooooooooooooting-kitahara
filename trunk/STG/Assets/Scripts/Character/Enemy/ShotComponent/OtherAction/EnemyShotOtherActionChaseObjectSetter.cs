/*===========================================================================*/
/*
*     * FileName    : EnemyShotOtherActionChaseObjectSetter.cs
*
*     * Description : ChaseGameObjectコンポーネントのrefChaseObject参照を切り替えるコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyShotOtherActionChaseObjectSetter : A_EnemyShotOtherAction
{
	public ChaseGameObject refChaseGameObject;
	
	public Transform refChangeTarget;
	
	public int delay;
	
	public override void OtherAction()
	{
		FrameRateUtility.StartCoroutine( delay, () =>
		{
			refChaseGameObject.refChaseObject = refChangeTarget;
		});
	}
}
