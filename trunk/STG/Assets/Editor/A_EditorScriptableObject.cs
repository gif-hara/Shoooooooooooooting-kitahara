/*===========================================================================*/
/*
*     * FileName    : A_EditorScriptableObject.cs
*
*     * Description : スクリプタぶるオブジェクトのエディター抽象クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;


public class A_EditorScriptableObject<T> : A_EditorBase where T : ScriptableObject
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
