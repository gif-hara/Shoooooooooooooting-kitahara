using UnityEngine;
using System.Collections;

public class UISpecialGaugeConditionPositionSetter : GameMonoBehaviour
{
	[SerializeField]
	private InputSpecialMode refInputSpecialMode;

	// Use this for initialization
	public override void Start ()
	{
		ReferenceManager.Instance.refUILayer.BroadcastMessage ( GameDefine.ModifiedNeedSpecialGaugeMessage, refInputSpecialMode.SpecialModeContent.NeedPoint );
	}
}
