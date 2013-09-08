/*===========================================================================*/
/*
*     * FileName    : EnemyShotCreator.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyShotCreator : GameMonoBehaviour
{
	public int shotId;

	public float speed;
	
	public int interval;
	
	public int number;
	
	public float range;
	
	private bool isSleep = false;
	
	private int sleepFrame = 0;
	
	private int currentInterval = 0;
	
	private int totalShotCount = 0;
	
	private List<EnemyShotCreateComponentBase> componentFromSetList = new List<EnemyShotCreateComponentBase>();
	private List<EnemyShotCreateComponentBase> componentFromAddList = new List<EnemyShotCreateComponentBase>();
	
	public override void Awake()
	{
		base.Awake();
		var list = new List<EnemyShotCreateComponentBase>( gameObject.GetComponents<EnemyShotCreateComponentBase>() );
		list.ForEach( (obj) =>
		{
			obj.Initialize( this );
			if( obj.setType == EnemyShotCreateComponent.SetType.Set )
			{
				componentFromSetList.Add( obj );
			}
			else if( obj.setType == EnemyShotCreateComponent.SetType.Add )
			{
				componentFromAddList.Add( obj );
			}
		});
	}
	
	public override void LateUpdate()
	{
		base.LateUpdate();
		if( !isSleep )
		{
			UpdateCreateShot();
		}
		else
		{
			UpdateSleep();
		}
	}
	/// <summary>
	/// 強制的に弾を発射させる.
	/// </summary>
	public void ForceFire()
	{
		enabled = true;
		isSleep = false;
		sleepFrame = 0;
		currentInterval = 0;
		UpdateCreateShot();
	}
	public void InitCurrentInterval( int value )
	{
		currentInterval = value;
	}
	
	public int Sleep
	{
		set
		{
			sleepFrame = value;
			isSleep = true;
		}
		get
		{
			return sleepFrame;
		}
	}
	
	public int TotalShotCount
	{
		get
		{
			return totalShotCount;
		}
	}
	protected void CreateShot()
	{
		if( number == 1 )
		{
			CreateShot( 0.0f );
		}
		else
		{
			float addRange = range / (number - 1);
			for( int i=0; i<number; i++ )
			{
				CreateShot( (addRange * i) - (range / 2.0f) );
			}
		}
		
		totalShotCount++;
	}
	protected void CreateShot( float _fixedAngle )
	{
		GameObject shot = (GameObject)InstantiateAsChild(
			ReferenceManager.refEnemyLayer,
			ReferenceManager.prefabEnemyShotList[shotId]
			);
		shot.GetComponent<EnemyShot>().Initialize( speed, transform, transform, _fixedAngle );
	}
	
	private void UpdateCreateShot()
	{
		if( currentInterval >= interval )
		{
			componentFromSetList.ForEach( (obj) =>
			{
				obj.Tuning();
			});
			componentFromAddList.ForEach( (obj) => 
			{
				obj.Tuning();
			});
			CreateShot();
			currentInterval = 0;
		}
		else
		{
			currentInterval++;
		}
	}
	
	private void UpdateSleep()
	{
		if( sleepFrame <= 0 )
		{
			isSleep = false;
		}
		else
		{
			sleepFrame--;
		}
	}
}
