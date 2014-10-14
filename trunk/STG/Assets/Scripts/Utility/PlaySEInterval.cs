/*===========================================================================*/
/*
*     * FileName    : PlaySEInterval.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlaySEInterval : GameMonoBehaviour
{
	/// <summary>
	/// 再生するラベル.
	/// </summary>
	public string label;
	
	/// <summary>
	/// 再生間隔.
	/// </summary>
	public int interval;
	
	/// <summary>
	/// 再生回数.
	/// </summary>
	[SerializeField]
	private int playNum;
	
	private int maxInterval;
	
	private int currentPlayNum = 0;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		maxInterval = interval;
	}
	
	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		if( interval <= 0 )
		{
			SoundManager.Instance.Play( label );
			interval = maxInterval;
			currentPlayNum++;
			
			if( playNum != 0 && playNum <= currentPlayNum )
			{
				enabled = false;
			}
		}
		else
		{
			interval--;
		}
	}
}
