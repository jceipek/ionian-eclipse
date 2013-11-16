﻿using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{
	public float m_health = 100f;
	
	private Rigidbody2D m_rigidbody;

	private GameObject m_shardPrefab;


	void OnEnable ()
	{
		m_rigidbody = GetComponent<Rigidbody2D> ();
		m_shardPrefab = Resources.Load ("Shard") as GameObject;
	}

	public void GetHit (float damage, Vector3 force)
	{
		m_rigidbody.AddForce (force);

		m_health -= damage;
		if (m_health <= 0) {
			StartCoroutine (Die (transform.position));
		}
	}

	IEnumerator Die (Vector3 position)
	{
		yield return new WaitForSeconds (0.5f);
		for (var i = 0; i < 10; i++) {
			Vector3 direction = Random.insideUnitCircle;
			GameObject shard = Instantiate (m_shardPrefab, position + direction, Quaternion.identity) as GameObject;
			FlyAway flyAway = shard.GetComponent<FlyAway> ();
			flyAway.InitWithDirection (direction);
		}
		Destroy (gameObject);
	}
}