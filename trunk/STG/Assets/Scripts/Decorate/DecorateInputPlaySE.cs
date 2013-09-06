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


public class DecorateInputPlaySE : A_Decorate<A_InputAction>
{
	public string label;
	
	public override void Decorate ()
	{
		ReferenceManager.Instance.refSoundManager.Play( label );
	}
}
