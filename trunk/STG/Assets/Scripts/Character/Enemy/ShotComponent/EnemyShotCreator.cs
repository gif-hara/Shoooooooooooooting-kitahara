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


public class EnemyShotCreator : GameMonoBehaviour, I_MuzzleEventActinable
{
	/// <summary>
	/// ショットID.
	/// </summary>
	public int shotId;
	
	/// <summary>
	/// 速度.
	/// </summary>
	public float speed;
	
	/// <summary>
	/// 発射間隔.
	/// </summary>
	public int interval;
	
	/// <summary>
	/// 発射数.
	/// </summary>
	public int number;
	
	/// <summary>
	/// 発射範囲.
	/// </summary>
	public float range;

	/// <summary>
	/// 一度の発射で何発出すか.
	/// </summary>
	public int multipleNum = 1;

	/// <summary>
	/// 発射ロックフラグ.
	/// </summary>
	public bool isLock = false;
	
	/// <summary>
	/// プレイヤーが自分より座標が上へ存在しているか.
	/// </summary>
	public bool isPlayerTop = false;
	
	/// <summary>
	/// 発射処理の休憩フラグ.
	/// </summary>
	private bool isSleep = false;
	
	/// <summary>
	/// 休憩フレーム.
	/// </summary>
	private int sleepFrame = 0;
	
	/// <summary>
	/// 現在の発射間隔.
	/// </summary>
	private int currentInterval = 0;
	
	/// <summary>
	/// 発射した総数.
	/// </summary>
	public int TotalShotCount{ get{ return totalShotCount; } }
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

		if( PauseManager.Instance.IsPause )	return;

		if( !isSleep )
		{
			UpdateCreateShot();
		}
		else
		{
			UpdateSleep();
		}
	}

	void OnDestroy()
	{
		gameObject.SendMessageUpwards( GameDefine.EnemyShotCreatorFreezeMessage, SendMessageOptions.DontRequireReceiver );
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
	}
	public void InitCurrentInterval( int value )
	{
		currentInterval = value;
	}
	/// <summary>
	/// 銃口がアクティブになった際のイベント.
	/// </summary>
	public void OnActiveMuzzle()
	{
		ForceFire();
	}
	public void Freeze( int interval )
	{
		enabled = false;
		this.interval = interval;
		gameObject.SendMessageUpwards( GameDefine.EnemyShotCreatorFreezeMessage, SendMessageOptions.DontRequireReceiver );
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
	
	protected void CreateShot()
	{
		for( int n=0; n<multipleNum; n++ )
		{
			componentFromSetList.ForEach( (obj) =>
			{
				obj.Tuning();
			});
			componentFromAddList.ForEach( (obj) => 
			{
				obj.Tuning();
			});

			// ロックされていたら撃たない.
			// プレイヤーが上へ存在していたら撃たない.
			if( isLock || isPlayerTop )
			{
				totalShotCount++;
				continue;
			}
			
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
	}
	protected void CreateShot( float _fixedAngle )
	{
		GameObject shot = Instantiate( ReferenceManager.prefabEnemyShotList[shotId] ) as GameObject;
		shot.GetComponent<EnemyShot>().Initialize( speed, transform.position, transform, _fixedAngle );
	}
	
	private void UpdateCreateShot()
	{
		if( currentInterval >= interval )
		{
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
