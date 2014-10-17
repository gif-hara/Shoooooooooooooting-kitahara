using UnityEngine;
using System.Collections;

public class UISpecialGaugeConditionPositionSetter : GameMonoBehaviour
{
	[SerializeField]
	private Player refPlayer;

	[SerializeField]
	private InputSpecialMode refInputSpecialMode;

	// Use this for initialization
	public override void Start ()
	{
		if( ReferenceManager == null )	return;

		ReferenceManager.Instance.refUILayer.BroadcastMessage ( GameDefine.ModifiedNeedSpecialGaugeMessage, refPlayer.PrefabSpecialModeContent.NeedPoint );
	}
}
