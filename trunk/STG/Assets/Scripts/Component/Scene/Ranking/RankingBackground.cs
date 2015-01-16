/*===========================================================================*/
/*
*     * FileName    : RankingBackground.cs
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
public class RankingBackground : MonoBehaviour
{
	[SerializeField]
	private MeshRenderer content;

	[SerializeField]
	private Material refFirstMaterial;

	[SerializeField]
	private Material refSecondMaterial;

	[SerializeField]
	private Material refThirdMaterial;
	
	void OnModifyRankingData( RankingData data )
	{
		if( data.Rank > 3 )
		{
			return;
		}

		content.material = GetMaterialFromRank( data.Rank );
	}

	private Material GetMaterialFromRank( int rank )
	{
		Material[] result =
		{
			refFirstMaterial,
			refSecondMaterial,
			refThirdMaterial,
		};

		return result[rank - 1];
	}
}
