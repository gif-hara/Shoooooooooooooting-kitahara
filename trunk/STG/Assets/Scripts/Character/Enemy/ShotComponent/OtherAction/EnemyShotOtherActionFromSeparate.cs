/*===========================================================================*/
/*
*     * FileName    : EnemyShotOtherActionFromSeparate.cs
*
*     * Description : 敵発射時に様々なアクションを行うコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyShotOtherActionFromSeparate : EnemyShotCreateComponentSeparate
{
	private List<A_EnemyShotOtherAction> refOtherActionList;
	
	public override void Initialize(EnemyShotCreator owner)
	{
		base.Initialize(owner);
		
		refOtherActionList = new List<A_EnemyShotOtherAction>( GetComponents<A_EnemyShotOtherAction>() );
	}
	
	protected override void TuningFromSet()
	{
		if( (owner.TotalShotCount + 1) % separate == 0 )
		{
			refOtherActionList.ForEach( (obj) =>
			{
				obj.OtherAction();
			});
		}
	}
	
	protected override void TuningFromAdd()
	{
		TuningFromSet();
	}
}
