/*===========================================================================*/
/*
*     * FileName    : AutoRotation.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class AutoRotation : MonoBehaviour
{
	public float speed;
	
	public Vector3 axis;

	[SerializeField]
	private float addSpeed;

	[SerializeField]
	private int interval = 0;

	private int currentInterval = 0;
	
	// Update is called once per frame
	void Update()
	{
		if( PauseManager.Instance.IsPause )	return;

		if( currentInterval < interval )
		{
			currentInterval++;
			return;
		}

		transform.localRotation *= Quaternion.AngleAxis( speed, axis );

		speed += addSpeed;
		currentInterval = 0;
	}

}
