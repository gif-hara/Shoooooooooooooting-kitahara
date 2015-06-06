/*===========================================================================*/
/*
*     * FileName    : EnemyShotRangeInitializeOnPool.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class EnemyShotRangeInitializeOnPool : MonoBehaviour, I_Poolable
{
	[SerializeField]
	private EnemyShotCreator refCreator;
	
	[SerializeField]
	private EnemyShotCreateComponent.Element element;
	
	public void OnAwakeByPool( bool used )
	{
		refCreator.range = element.Evalute();
	}
	
	public void OnReleaseByPool()
	{
		
	}
}
