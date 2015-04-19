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


public class MeshUVOffsetTile : MonoBehaviourExtension, I_Poolable
{
	public GameObject refDestroyObject;
	
	public MeshFilter refMesh;
		
	public int tileX;
	
	public int tileY;
	
	public int interval;
	
	public bool loop;

	public int initialOffset = 0;

	[SerializeField]
	private GameDefine.CreateType createType = GameDefine.CreateType.Instantiate;
	
	private Mesh mesh;
	
	private int timer = 0;
	
	private int offset = 0;
	
	private float intervalX = 0.0f;
	
	private float intervalY = 0.0f;

	public override void Start ()
	{
		base.Start ();
		this.mesh = refMesh.mesh;
		Initialize();
		UpdateUv();
	}
	// Update is called once per frame
	public override void Update ()
	{
		base.Update();

		if( PauseManager.Instance.IsPause )	return;

		if( this.timer >= this.interval )
		{
			this.offset++;
			if( !loop && offset >= (tileX * tileY) )
			{
				if( createType == GameDefine.CreateType.Instantiate )
				{
					Destroy( refDestroyObject );
				}
				else
				{
					if( refDestroyObject != null )
					{
						ObjectPool.Instance.ReleaseGameObject( refDestroyObject );
					}
				}
				this.refMesh.renderer.enabled = false;
				this.enabled = false;
			}
			UpdateUv();
			this.timer = 0;
			return;
		}
		this.timer++;
	}

	public void OnAwakeByPool( bool used )
	{
		this.refMesh.renderer.enabled = true;
		this.enabled = true;
		this.offset = this.initialOffset;
		this.refMesh.gameObject.SetActive( true );
	}

	public void OnReleaseByPool()
	{

	}
	
	void OnDestroy()
	{
		Destroy( mesh );
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
		mesh.uv = new Vector2[]
        {
            new Vector2( left, bottom ),
            new Vector2( right, bottom ),
            new Vector2( left, top ),
            new Vector2( right, top )
        };
	}
}
