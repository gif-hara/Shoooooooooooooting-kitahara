/*===========================================================================*/
/*
*     * FileName    : ObserverBase.cs
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
public class ObserverBase<T> : MonoBehaviour where T : MonoBehaviour
{
	[SerializeField]
	protected T content;
}
