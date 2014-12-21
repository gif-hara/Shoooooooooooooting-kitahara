/*===========================================================================*/
/*
*     * FileName    : RankingPlayerTextureMeshRenderer.cs
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
public class RankingPlayerTextureMeshRenderer : MonoBehaviour
{
	[SerializeField]
	private MeshRenderer content;

	[SerializeField]
	private List<Material> refMaterials;
	
	void OnModifyRankingData( RankingData data )
	{
		content.material = refMaterials[data.PlayerId];
	}
}
