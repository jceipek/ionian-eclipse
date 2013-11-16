using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{
		public float m_startHealth = 100f;

		public float m_health;
		
		public Transform m_respawner;
		
		public string m_shipType;
	
		private Rigidbody2D m_rigidbody;

		private GameObject m_shardPrefab;
		
		public void SetRespawner (Transform newSpawner)
		{
				m_respawner = newSpawner;
		}
		
		void OnEnable ()
		{
				m_rigidbody = GetComponent<Rigidbody2D> ();
				m_shardPrefab = Resources.Load ("Shard") as GameObject;
				m_health = m_startHealth;
		}

		public void GetHit (float damage, Vector3 force)
		{
				m_rigidbody.AddForce (force);

				m_health -= damage;
				if (m_health <= 0) {
						StartCoroutine (Die ());
				}
		}

		public float GetHealthRatio ()
		{
				return m_health / m_startHealth;
		}

		IEnumerator Die ()
		{
				yield return new WaitForSeconds (0.5f);
				for (var i = 0; i < 10; i++) {
						Vector3 direction = Random.insideUnitCircle;
						GameObject shard = Instantiate (m_shardPrefab, transform.position + direction, Quaternion.identity) as GameObject;
						FlyAway flyAway = shard.GetComponent<FlyAway> ();
						flyAway.InitWithDirection (direction);
				}
				if (m_respawner) {
						m_respawner.gameObject.SendMessage ("Respawn", m_shipType);
				}
				Destroy (gameObject);
		}
}