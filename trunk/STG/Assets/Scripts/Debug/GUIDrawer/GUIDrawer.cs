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
	
	void OnGUI()
	{
		GUI.Box( boxRect, "" );
		GUILayout.BeginVertical();
		elementList.ForEach( (obj) =>
		{
			obj.Draw();
		});
		GUILayout.EndVertical();
	}
}
