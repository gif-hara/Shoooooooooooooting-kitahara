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

	private MeshColorManager meshManager;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();

		if( refMeshFilter == null )
		{
			refMeshFilter = GetComponent<MeshFilter>();
		}

		meshManager = new MeshColorManager();
		meshManager.Initialize( refMeshFilter );
		meshManager.SetColor( color );
	}
}
