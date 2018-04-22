using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGravity : MonoBehaviour {

	public void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		}
	}
}
