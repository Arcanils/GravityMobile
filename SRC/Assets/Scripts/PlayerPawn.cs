using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPawn : MonoBehaviour {

	public Action OnDeath;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag == "Killzone")
		{
			if (OnDeath != null)
				OnDeath();

			Destroy(gameObject);
		}
	}
}
