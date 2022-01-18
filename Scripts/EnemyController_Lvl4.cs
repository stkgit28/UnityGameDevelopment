using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController_Lvl4 : MonoBehaviour
{

	private void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.gameObject.GetComponent<PlayerController_Lvl4>().IsHurt();
		}
	}
}
