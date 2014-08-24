/*===========================================================================*/
/*
*     * FileName    : MeshColorSetterLerp.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MeshColorSetterLerp : MonoBehaviourExtension
{
	[System.Serializable]
	public class LerpData
	{
		public Color Color{ get{ return this.color; } }
		[SerializeField]
		private Color color;

		public int Duration{ get{ return this.duration; } }
		[SerializeField]
		private int duration;

		public AnimationCurve Curve{ get{ return this.curve; } }
		[SerializeField]
		private AnimationCurve curve;
	}

	[SerializeField]
	private MeshFilter refMeshFilter;
	
	[SerializeField]
	private List<LerpData> lerpDataList;

	private MeshColorManager meshManager;

	private int currentDuation = 0;

	private int id = 0;

	private Color fromColor;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		meshManager = new MeshColorManager();
		meshManager.Initialize( refMeshFilter );
	}

	public override void Update ()
	{
		base.Update ();

		var lerpData = lerpDataList[id % this.lerpDataList.Count];
		this.meshManager.SetColor( Color.Lerp( this.fromColor, lerpData.Color, lerpData.Curve.Evaluate( (float)this.currentDuation / lerpData.Duration ) ) );

		currentDuation++;

		if( this.currentDuation > lerpData.Duration )
		{
			id++;
			this.fromColor = meshManager.CurrentColor;
			currentDuation = 0;
		}
	}
}
