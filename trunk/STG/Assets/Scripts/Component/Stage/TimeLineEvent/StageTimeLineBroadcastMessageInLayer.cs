/*===========================================================================*/
/*
*     * FileName    : StageTimeLineBroadcastMessageInLayer.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// レイヤーオブジェクトに対してBroascastMessageを流すタイムラインアクションコンポーネント.
/// </summary>
public class StageTimeLineBroadcastMessageInLayer : A_StageTimeLineActionable
{
	[SerializeField]
	private GameDefine.LayerType layerType;

	[SerializeField]
	private string message;

	public override void Action ()
	{
		ReferenceManager.Instance.GetLayerObject( this.layerType ).BroadcastMessage( this.message );
	}
	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}] BroascastMessage", timeLine );
		}
	}
}
