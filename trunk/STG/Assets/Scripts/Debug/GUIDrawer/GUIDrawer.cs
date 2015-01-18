/*===========================================================================*/
/*
*     * FileName    : GUIDrawer.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GUIDrawer : MonoBehaviour
{
	private List<A_GUIElement> elementList;

	public bool IsDraw{ set{ isDraw = value; } get{ return isDraw; } }
	[SerializeField]
	private bool isDraw;

	[SerializeField]
	private Rect boxRect;
	
	void Awake()
	{
		elementList = new List<A_GUIElement>();
		for( int i=0,imax=transform.childCount; i<imax; i++ )
		{
			elementList.Add( transform.GetChild( i ).GetComponent<A_GUIElement>() );
		}
		elementList.Sort( (x, y) => x.priority - y.priority );
	}

	void Start()
	{
#if !UNITY_EDITOR
		Destroy( gameObject );
#endif
	}
	
	void OnGUI()
	{
		if( !isDraw )	return;

		GUI.Box( boxRect, "" );
		GUILayout.BeginVertical();
		elementList.ForEach( (obj) =>
		{
			obj.Draw();
		});
		GUILayout.EndVertical();
	}
}
