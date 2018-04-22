using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	public enum ETriggerType
	{
		START,
		END,
	}

	public ETriggerType Type;
	public Action OnTriggerEnter;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.tag == "Player" && Type == ETriggerType.END && OnTriggerEnter != null)
		{
			OnTriggerEnter();
		}
	}
}
