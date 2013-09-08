/*===========================================================================*/
/*
*     * FileName    : FPSGUI.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class FPSGUI : A_GUIElement
{
	private float oldTime;
	private int frame = 0;
	private float frameRate = 0f;
	private string frameRateStr = "";
	private const float INTERVAL = 0.5f; // この時間おきにFPSを計算して表示させる
	
	public override void Start()
	{
		base.Start();
		oldTime = Time.realtimeSinceStartup;
	}
	
	public override void Update()
	{
		base.Update();
		frame++;
		float time = Time.realtimeSinceStartup - oldTime;
		if (time >= INTERVAL)
		{
			// この時点でtime秒あたりのframe数が分かる.
			// time秒を1秒あたりに変換したいので、frame数からtimeを割る.
			frameRate = (float)frame / time;
			frameRateStr = frameRate.ToString( "0.00" );
			oldTime = Time.realtimeSinceStartup;
			frame = 0;
		}
	}
	
	public override void Draw ()
	{
		Label( string.Format( "{0}fps", frameRateStr ) );
	}
}
