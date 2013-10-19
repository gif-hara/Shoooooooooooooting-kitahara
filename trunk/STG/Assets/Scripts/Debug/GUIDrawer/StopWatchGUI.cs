/*===========================================================================*/
/*
*     * FileName    : StopWatchGUI.cs
*
*     * Description : ストップウォッチGUIコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StopWatchGUI : A_GUIElement
{
	private float timer = 0.0f;
	
	private int frameTimer = 0;
	
	[SerializeField]
	private bool isRun = false;
	
	public override void Update()
	{
		if( !isRun )	return;
		
		timer += Time.deltaTime;
		frameTimer++;
	}
	
	public override void Draw()
	{
		string format = string.Format( "StopWatch{0}Time = {1}{0}Frame = {2}",
			System.Environment.NewLine, timer, frameTimer
			);
		Label( format );
	}
	
	public void Run()
	{
		isRun = true;
	}
	
	public void Stop()
	{
		isRun = false;
	}
	
	public void Toggle()
	{
		isRun = !isRun;
	}
	
	public void Reset()
	{
		timer = 0.0f;
		frameTimer = 0;
	}
}
