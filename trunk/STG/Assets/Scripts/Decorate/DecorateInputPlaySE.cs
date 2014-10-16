/*===========================================================================*/
/*
*     * FileName    : DecorateInputPlaySE.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class DecorateInputPlaySE : A_Decorate
{
	public string label;
	
	public override void Decorate ()
	{
		SoundManager.Instance.Play( label );
	}
}
