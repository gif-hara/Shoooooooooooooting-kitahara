//================================================
/*!
    @file   TweenMeshColor.cs

    @brief  .

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class TweenMeshColor : MonoBehaviour
{
	[SerializeField]
	private MeshFilter refMeshFIlter;

	[SerializeField]
	private int duration;

	[SerializeField]
	private Color from = Color.white;

	[SerializeField]
	private Color to = Color.white;

	private MeshColorManager meshManager;

	private int currentDuration;

	// Use this for initialization
	void Start ()
	{
		meshManager = new MeshColorManager();
		meshManager.Initialize( refMeshFIlter );
		meshManager.SetColor( from );
		currentDuration = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if( currentDuration > duration )
		{
			enabled = false;
			return;
		}
		meshManager.SetColor( Color.Lerp( from, to, (float)currentDuration / (float)duration ) );
		currentDuration++;
	}
}
