/*===========================================================================*/
/*
*     * FileName    : A_Editor.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using UnityEditor;
using System.Collections;
using System;


public class A_EditorMonoBehaviour<T> : A_EditorBase where T : MonoBehaviour
{
	private T _target = null;
	
	protected T Target
	{
		get
		{
			if( _target == null )
			{
				_target = (T)target;
			}
			return _target;
		}
	}
}
