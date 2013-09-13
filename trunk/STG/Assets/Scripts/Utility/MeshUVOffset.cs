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
	public GameObject refDestroyObject;
	
	public MeshFilter refMesh;
		
	public int tileX;
	
	public int tileY;
	
	public int interval;
	
	public bool loop;
	
	private Mesh mesh;
	
	private int timer = 0;
	
	private int offset = 0;
	
	private float intervalX = 0.0f;
	
	private float intervalY = 0.0f;
	
	private readonly Vector2 UVLeftDown = new Vector2( 0.0f, 0.0f );
	
	private readonly Vector2 UVRightDown = new Vector2( 1.0f, 0.0f );
	
	private readonly Vector2 UVLeftUp = new Vector2( 0.0f, 1.0f );
	
	private readonly Vector2 UVRightUp = new Vector2( 1.0f, 1.0f );
	
	// Use this for initialization
	public override void Start()
	{
		mesh = refMesh.mesh;
		Initialize();
		UpdateUv();
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
		
		if( timer >= interval )
		{
			offset++;
			if( !loop && offset >= (tileX * tileY) )
			{
				Destroy( refDestroyObject );
			}
			UpdateUv();
			timer = 0;
			return;
		}
		timer++;
	}
	
	private void Initialize()
	{
		intervalX = 1.0f / tileX;
		intervalY = 1.0f / tileY;
	}
	
	private void UpdateUv()
	{
		float left = intervalX * (offset % tileX);
		float top = 1.0f - (intervalY * (float)(offset / tileX));
		float right = (intervalX * (offset % tileX)) + intervalX;
		float bottom = 1.0f - (intervalY * (float)((offset / tileX) + 1));
		
		Debug.Log( string.Format( "left = {1}{0}top = {2}{0}right = {3}{0}bottom = {4}{0}",
			System.Environment.NewLine,
			left,
			top,
			right,
			bottom
			));
		
		Vector2[] uvList = new Vector2[4];
		uvList[0] = new Vector2( left, bottom );
		uvList[1] = new Vector2( right, bottom );
		uvList[2] = new Vector2( left, top );
		uvList[3] = new Vector2( right, top );
		mesh.uv = uvList;
	}
}
