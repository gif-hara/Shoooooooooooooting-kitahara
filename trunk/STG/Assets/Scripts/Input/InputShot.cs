/*===========================================================================*/
/*
*     * FileName    : InputShot.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;


public class InputShot : A_InputAction
{
	[SerializeField]
	private List<PlayerShotFire> refPlayerShotFireList;

	/// <summary>
	/// ショットプレハブ.
	/// </summary>
	public GameObject prefabShot;
	
	/// <summary>
	/// 生成姿勢参照.
	/// </summary>
	public Transform refInstancePosition;
	
	/// <summary>
	/// ショットアングル参照.
	/// </summary>
	public Transform refShotAngle;
	
	/// <summary>
	/// 速度.
	/// </summary>
	public float speed;
	
	/// <summary>
	/// 発射間隔.
	/// </summary>
	public int interval;
	
	/// <summary>
	/// 最大発射数.
	/// </summary>
	public int maxFire;
	
	/// <summary>
	/// 内部タイマー.
	/// </summary>
	private int timer;
	
	/// <summary>
	/// 今発射している数.
	/// </summary>
	private int currentFireNum;

	private bool isFire = true;
	
	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		if( Input.GetKey( KeyCode.Z ) )
		{
			refPlayerShotFireList.ForEach( p => p.Fire() );
		}
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
