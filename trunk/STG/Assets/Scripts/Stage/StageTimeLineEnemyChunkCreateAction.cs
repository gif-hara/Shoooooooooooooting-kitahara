//================================================
/*!
    @file   StageTimeLineEnemyChunkCreateAction.cs

    @brief  .

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StageTimeLineEnemyChunkCreateAction : A_StageTimeLineActionable
{
	/// <summary>
	/// タイムライン.
	/// </summary>
	private int timeLine = 0;
	
	private bool isUpdate = false;
	
	public override void Update()
	{
		base.Update();
	}
	
	public override void Action()
	{
		isUpdate = true;
	}
	
	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}] EnemyChunkCreate", timeLine );
		}
	}
}
