/*===========================================================================*/
/*
*     * FileName    : PlayerShotFire.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class PlayerShotFire : GameMonoBehaviour
{
	/// <summary>
	/// ショットプレハブ.
	/// </summary>
	[SerializeField]
	private GameObject prefabShot;
	
	/// <summary>
	/// 生成姿勢参照.
	/// </summary>
	[SerializeField]
	private Transform refInstancePosition;
	
	/// <summary>
	/// ショットアングル参照.
	/// </summary>
	[SerializeField]
	private Transform refShotAngle;
	
	/// <summary>
	/// 速度.
	/// </summary>
	[SerializeField]
	private float speed;
	
	/// <summary>
	/// 発射間隔.
	/// </summary>
	[SerializeField]
	private int interval;
	
	/// <summary>
	/// 最大発射数.
	/// </summary>
	[SerializeField]
	private int maxFire;
	
	/// <summary>
	/// 内部タイマー.
	/// </summary>
	private int timer;
	
	/// <summary>
	/// 今発射している数.
	/// </summary>
	private int currentFireNum;

	protected DecorateManager decorateManager;
	
	private bool isFire = true;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		decorateManager = new DecorateManager( Trans );
	}
	
	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		timer++;
	}

	public void Fire()
	{
		if( !isFire )	return;
		if( currentFireNum >= maxFire )	return;
		if( timer < interval )	return;

		decorateManager.Decorate();
		timer = 0;
		GameObject shot = Instantiate( prefabShot ) as GameObject;
		shot.AddComponent<PlayerShot>().Initialize( this, speed, refInstancePosition.position, refShotAngle );
		currentFireNum++;
	}

	/// <summary>
	/// 発射数の減算.
	/// </summary>
	public void Cool()
	{
		currentFireNum--;
	}
	
	void OnStartResult()
	{
		isFire = false;
	}
	
	void OnStartStage()
	{
		isFire = true;
	}
}
