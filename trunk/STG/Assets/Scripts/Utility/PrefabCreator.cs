/*===========================================================================*/
/*
*     * FileName    : PrefabCreator.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PrefabCreator : GameMonoBehaviour
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
	
	void Awake()
	{
		if( createType == CreateType.Awake )
		{
			Create();
		}
	}
	// Use this for initialization
	void Start()
	{
		if( createType == CreateType.Start )
		{
			Create();
		}
	}
	void Update()
	{
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
			Transform p = InstantiateAsChild( obj.parent, obj.prefab ).transform;
			p.gameObject.layer = obj.prefab.layer;
			
			p.localRotation = Quaternion.identity;
			p.localPosition = Vector3.zero;
			if( obj.detachParent )
			{
				p.parent = null;
			}
		});
	}
}
