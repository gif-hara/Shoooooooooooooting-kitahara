/*===========================================================================*/
/*
*     * FileName    : InputSpecialMode.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class InputSpecialMode : MonoBehaviour
{
	[SerializeField]
	private Player refPlayer;
	
	// Update is called once per frame
	void Update()
	{
		UpdateIsValid();
	}
	
	private void UpdateIsValid()
	{
		if( Input.GetKeyDown( KeyCode.X ) )
		{
			refPlayer.StartSpecialMode();
		}
	}
}
