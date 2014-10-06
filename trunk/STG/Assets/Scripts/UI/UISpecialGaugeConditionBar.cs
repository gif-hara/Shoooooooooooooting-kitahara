/*===========================================================================*/
/*
*     * FileName    : UISpecialGaugeConditionBar.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

public class UISpecialGaugeConditionBar : GameMonoBehaviour
{
	[SerializeField]
	private Vector3 minPosition;

	[SerializeField]
	private Vector3 maxPosition;

	void OnModifiedNeedSpecialGauge( float needValue )
	{
		Trans.localPosition = Vector3.Lerp (minPosition, maxPosition, needValue / PlayerStatusManager.MaxSpecialPoint);
	}
}
