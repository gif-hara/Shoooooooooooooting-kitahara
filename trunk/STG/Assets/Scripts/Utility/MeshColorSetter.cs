/*===========================================================================*/
/*
*     * FileName    : MeshColorSetter.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MeshColorSetter : MonoBehaviourExtension
{
	public MeshFilter refMeshFilter;
	
	public Color color;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		
		var mesh = refMeshFilter.mesh;
		Color[] colors = new Color[mesh.colors.Length];
		for( int i=0,imax=colors.Length; i<imax; i++ )
		{
			colors[i] = color;
		}
		
		mesh.colors = colors;
	}
}
