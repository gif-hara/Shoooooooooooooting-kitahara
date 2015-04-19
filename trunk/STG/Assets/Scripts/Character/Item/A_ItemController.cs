/*===========================================================================*/
/*
*     * FileName    :A_ItemController.cs
*
*     * Description : .
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
public abstract class A_ItemController : GameMonoBehaviour, I_Poolable
{
	public virtual void OnAwakeByPool( bool used )
	{
	}

	public virtual void OnReleaseByPool()
	{
	}

	public abstract bool IsFirstMove
	{
		get;
	}

	public abstract void StartChasePlayer();

	public abstract void OnPlayerCollide();
}
