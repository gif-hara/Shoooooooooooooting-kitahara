/*===========================================================================*/
/*
*     * FileName    : ShadowManager.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 影管理者クラス.
/// </summary>
public class ShadowManager : GameMonoBehaviour
{
	public Shadow PrefabShadow{ get{ return this.prefabShadow; } }
	[SerializeField]
	private Shadow prefabShadow;

	public Vector3 Offset{ set{ this.offset = value; } get{ return this.offset; } }
	[SerializeField]
	private Vector3 offset;

	public Vector3 Scale{ set{ this.scale = value; } get{ return this.scale; } }
	[SerializeField]
	private Vector3 scale;
}
