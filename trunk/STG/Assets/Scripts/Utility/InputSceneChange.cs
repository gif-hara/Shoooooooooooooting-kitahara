/*===========================================================================*/
/*
*     * FileName    : InputSceneChange.cs
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
public class InputSceneChange : MonoBehaviour
{
	[SerializeField]
	private SceneManager.EffectType startEffectType;
	
	[SerializeField]
	private SceneManager.EffectType endEffectType;
	
	[SerializeField]
	private string sceneName;

	void Update ()
	{
		if( MyInput.FireKeyDown )
		{
			SceneManager.Instance.Change( startEffectType, endEffectType, sceneName );
		}
	}
}
