using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGravityComponent : MonoBehaviour {

	public float CutVelocity = 1f;
	public float CoefAdd = 2f;
	private Rigidbody2D _rigid;
	private int _enableFeature = 1;
	private void Awake()
	{
		_rigid = GetComponent<Rigidbody2D>();
	}

	public void FixedUpdate()
	{
		if (_enableFeature == 0)
		{
			ApplyGravity1();
		}
		else if (_enableFeature == 1)
		{
			ApplyGravity2();
		}

	}


	public void OnGUI()
	{
		if (GUI.Button(new Rect(Vector2.zero, new Vector2(200f, 200f)), "Enable Mode : " + _enableFeature))
		{
			_enableFeature = (_enableFeature + 1) % 3;
		}
		CoefAdd = GUI.HorizontalSlider(new Rect(new Vector2(200f, 100f), new Vector2(400f, 200f)), CoefAdd, 0f, 2f);

		CutVelocity = GUI.HorizontalSlider(new Rect(new Vector2(200f, 300), new Vector2(400f, 200f)), CutVelocity, 0f, 100f);
	}

	public void ApplyGravity1()
	{
		var velocity = _rigid.velocity;
		var gravity = Physics2D.gravity;
		var gravityXPositif = Mathf.Sign(gravity.x) > 0f;
		var gravityYPositif = Mathf.Sign(gravity.y) > 0f;
		var velocityXPositif = Mathf.Sign(velocity.x) > 0f;
		var velocityYPositif = Mathf.Sign(velocity.y) > 0f;

		if (gravityXPositif ^ velocityXPositif)
		{
			velocity.x += gravity.x * _rigid.gravityScale * CoefAdd;
		}
		if (gravityYPositif ^ velocityYPositif)
		{
			velocity.y += gravity.y * _rigid.gravityScale * CoefAdd;
		}

		_rigid.velocity = velocity;
	}

	public void ApplyGravity2()
	{
		var velocity = _rigid.velocity;
		var gravity = Physics2D.gravity;
		var gravityXPositif = Mathf.Sign(gravity.x) > 0f;
		var gravityYPositif = Mathf.Sign(gravity.y) > 0f;
		var velocityXPositif = Mathf.Sign(velocity.x) > 0f;
		var velocityYPositif = Mathf.Sign(velocity.y) > 0f;

		if (gravityXPositif ^ velocityXPositif)
		{
			velocity.x = Mathf.Clamp(velocity.x, -CutVelocity, CutVelocity);
		}
		if (gravityYPositif ^ velocityYPositif)
		{
			velocity.y = Mathf.Clamp(velocity.y, -CutVelocity, CutVelocity);
		}

		_rigid.velocity = velocity;
	}
}
