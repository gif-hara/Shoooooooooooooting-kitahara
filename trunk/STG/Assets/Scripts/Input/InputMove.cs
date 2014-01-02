/*===========================================================================*/
/*
*     * FileName    : InputMove.cs
*
*     * Description : キー入力による移動クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/

using UnityEngine;
using System.Collections;

public class InputMove : MonoBehaviour
{
	/// <summary>
	/// 移動させるオブジェクト.
	/// </summary>
	public Transform refTrans;
		
	/// <summary>
	/// 通常の移動速度.
	/// </summary>
	public float m_u_normalSpeed = 1.0f;
	
	/// <summary>
	/// シフト移動時の速度.
	/// </summary>
	public float m_u_shiftSpeed = 0.5f;
	
	private float m_speed = 0.0f;

	private readonly Rect limit = new Rect( -295.0f, 275.0f, 295.0f, -260.0f );

	// Update is called once per frame
	void Update()
	{		
		refTrans.localPosition += getFinalVelocity();
		FixedPosition();
	}
	
	/// <summary>
	/// キー入力による移動量を返す.
	/// </summary>
	/// <returns>
	/// The input velocity.
	/// </returns>
	private Vector3 getInputVelocity()
	{
		Vector3 velocity = Vector3.zero;
		
		if( Input.GetButton( "Up" ) || Input.GetKey( KeyCode.UpArrow ) )
		{
			velocity += Vector3.up;
		}
		else if( Input.GetButton( "Down" ) || Input.GetKey( KeyCode.DownArrow ) )
		{
			velocity += Vector3.down;
		}
		if( Input.GetButton( "Left" ) || Input.GetKey( KeyCode.LeftArrow ) )
		{
			velocity += Vector3.left;
		}
		else if( Input.GetButton( "Right" ) || Input.GetKey( KeyCode.RightArrow ) )
		{
			velocity += Vector3.right;
		}
		
		return velocity.normalized;
	}
	
	private float getSpeed()
	{
		float targetSpeed = Input.GetButton( "Shift" ) ? m_u_shiftSpeed : m_u_normalSpeed;
		
		m_speed += (targetSpeed - m_speed);
		
		return m_speed;
	}
	
	private Vector3 getFinalVelocity()
	{
		return getInputVelocity() * getSpeed() * Time.deltaTime;
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
/* End of file ==============================================================*/
