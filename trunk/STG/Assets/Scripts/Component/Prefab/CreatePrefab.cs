/*===========================================================================*/
/*
*     * FileName    : CreatePrefab.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CreatePrefab : GameMonoBehaviour
{
	[System.Serializable]
	public class Element
	{
		public GameObject prefab;
		
		public Transform parent;
		
		public bool detachParent = false;
	}
	
	public enum CreateType : int
	{
		Awake,
		Start,
		Update,
	}
	
	public CreateType createType;
	
	public List<Element> elementList;
	
	public int delay;

	[SerializeField]
	private GameDefine.CreateType objectCreateType = GameDefine.CreateType.Instantiate;
	
	public override void Awake()
	{
		base.Awake();
		if( createType == CreateType.Awake )
		{
			Create();
		}
	}
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		if( createType == CreateType.Start )
		{
			Create();
		}
	}
	public override void Update()
	{
		base.Update();

		if( PauseManager.Instance.IsPause )	return;
		
		if( createType != CreateType.Update )	return;
		
		if( delay <= 0 )
		{
			Create();
			enabled = false;
		}
		
		delay--;
	}
	private void Create()
	{
		elementList.ForEach( (obj) => 
		{
			Create( obj );
		});
	}

	private void Create( Element element )
	{
		Transform obj = null;

		if( this.objectCreateType == GameDefine.CreateType.Pool )
		{
			obj = ObjectPool.Instance.GetGameObject( element.prefab ).transform;
			if( element.parent != null )
			{
				obj.parent = element.parent;
			}
		}
		else
		{
			obj = element.parent == null
				? (Instantiate( element.prefab, element.prefab.transform.position, element.prefab.transform.rotation ) as GameObject).transform
				: InstantiateAsChild( element.parent, element.prefab ).transform;
		}

		obj.gameObject.layer = element.prefab.layer;

		if( element.parent != null )
		{
			obj.localRotation = Quaternion.identity;
			obj.localPosition = Vector3.zero;
		}

		if( element.detachParent )
		{
			obj.parent = null;
		}
	}
}
