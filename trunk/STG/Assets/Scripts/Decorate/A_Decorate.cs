/*===========================================================================*/
/*
*     * FileName    : A_Decorate.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public abstract class A_Decorate<T> : MonoBehaviour where T : MonoBehaviour
{
	protected T owner;
	
	public void Initialize( T owner )
	{
		this.owner = owner;
	}
	
	public abstract void Decorate();
}
