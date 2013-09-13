//================================================
/*!
    @file   MeshUVOffset.cs

    @brief  .

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MeshUVOffset : MonoBehaviourExtension
{
	public MeshFilter refMesh;
	
	public List<Vector2> uvs;
	
	private Mesh mesh;
	
	public int tileX;
	
	public int tileY;
	
	private readonly Vector2 UVLeftDown = new Vector2( 0.0f, 0.0f );
	
	private readonly Vector2 UVRightDown = new Vector2( 1.0f, 0.0f );
	
	private readonly Vector2 UVLeftUp = new Vector2( 0.0f, 1.0f );
	
	private readonly Vector2 UVRightUp = new Vector2( 1.0f, 1.0f );
	
	// Use this for initialization
	public override void Start()
	{
		mesh = refMesh.mesh;
		var uv = mesh.uv;
		foreach( var u in mesh.uv )
		{
			Debug.Log( "uv = " + u );
		}
		foreach( var v in mesh.vertices )
		{
			Debug.Log( "vertice = " + v );
		}
		foreach( var t in mesh.triangles )
		{
			Debug.Log( "triangle = " + t );
		}
	}
	
	// Update is called once per frame
	public override void Update ()
	{
		mesh.uv = uvs.ToArray();
	}
}
