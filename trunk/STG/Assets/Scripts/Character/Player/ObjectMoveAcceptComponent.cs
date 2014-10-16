/*===========================================================================*/
/*
*     * FileName    : ObjectMoveAcceptComponent.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 他のコンポーネントの処理を受け入れてオブジェクトを異動させるコンポーネント.
/// </summary>
public class ObjectMoveAcceptComponent : MonoBehaviour
{
	/// <summary>
	/// 移動させるオブジェクト.
	/// </summary>
	[SerializeField]
	private Transform refTrans;

	[SerializeField]
	private float speed = 0.0f;

	private Vector3 velocity = Vector3.zero;

	private readonly Rect limit = new Rect( -350.0f, 280.0f, 350.0f, -255.0f );
	
	// Update is called once per frame
	void LateUpdate()
	{		
		refTrans.localPosition += getFinalVelocity();
		FixedPosition();
		velocity = Vector3.zero;
	}

	public void Up()
	{
		velocity += Vector3.up;
	}
	
	public void Down()
	{
		velocity += Vector3.down;
	}
	
	public void Left()
	{
		velocity += Vector3.left;
	}
	
	public void Right()
	{
		velocity += Vector3.right;
	}

	public void ChangeSpeed( float value )
	{
		speed = value;
	}

	private Vector3 getFinalVelocity()
	{
		return velocity.normalized * speed;
	}
	/// <summary>
	/// 座標の修正.
	/// </summary>
	private void FixedPosition()
	{
		var pos = refTrans.localPosition;
		pos.x = pos.x < limit.x ? limit.x : pos.x;
		pos.x = pos.x > limit.width ? limit.width : pos.x;
		pos.y = pos.y > limit.y ? limit.y : pos.y;
		pos.y = pos.y < limit.height ? limit.height : pos.y;
		
		refTrans.localPosition = pos;
	}
}
