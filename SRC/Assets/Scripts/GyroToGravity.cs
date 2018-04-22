using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroToGravity : MonoBehaviour {

	enum ETestSwitchVar
	{
		X,
		Y,
		Z
	}

	public float GravityForce = 9.81f;
	public UnityEngine.UI.Text TextDebug;
	private Vector2 _newGravity;


	private ETestSwitchVar _currentType;
	private float _offset;

	private void Update()
	{
		var vecBase = Vector2.right;
		var gyro = Input.acceleration;
		var dir = new Vector2(gyro.x, gyro.y);
		if (dir == Vector2.zero)
			return;

		dir.Normalize();
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

		_newGravity = vecBase.Rotate(angle + _offset) * GravityForce;
		Physics2D.gravity = _newGravity;
		TextDebug.text = Input.acceleration + " " + _newGravity;
	}
	public void OnGUI()
	{
		var width = (Screen.width - 20) / 3f;
		var height = Screen.height / 8f;
		//GUI.Label(new Rect(10, 10, width, height), Input.acceleration + " " +  _newGravity);
		if (GUI.Button(new Rect(0, 10, width, height), "Add degre"))
		{
			_offset = (_offset + 90f) % 360f;
		}
		/*
		if (GUI.Button(new Rect(10 + 2 * width, 10, width, height), "Switch Var : " + _currentType.ToString()))
		{
			_currentType = (ETestSwitchVar)(((int)_currentType + 1) % 3);
		}
		*/
	}
}

public static class VectorExt
{
	private const float DegToRad = Mathf.PI / 180f;

	public static Vector2 Rotate(this Vector2 v, float degrees)
	{
		return v.RotateRadians(degrees * DegToRad);
	}

	public static Vector2 RotateRadians(this Vector2 v, float radians)
	{
		var ca = Mathf.Cos(radians);
		var sa = Mathf.Sin(radians);
		return new Vector2(ca * v.x - sa * v.y, sa * v.x + ca * v.y);
	}
}