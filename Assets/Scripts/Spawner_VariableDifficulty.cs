using UnityEngine;
using System.Collections;

public class Spawner_VariableDifficulty : MonoBehaviour
{
		public GameObject m_enemyPrefab;
		public float m_dicfficulty_level = 0.2f;
		//TODO: Change to be dependant on time since game has started
		public float m_spawningRate; 
		public int m_enemyCountPerSpawn = 1;

		void OnEnable ()
		{
				m_enemyPrefab = Resources.Load ("Enemy") as GameObject;
		}
	
		void Start ()
		{
				StartCoroutine (Spawn ());	
		}
	
		IEnumerator Spawn ()
		{
				while (true) {
						yield return (new WaitForSeconds (m_spawningRate));
						for (int i = 0; i < m_enemyCountPerSpawn; i++) {
								GameObject enemy = Instantiate (m_enemyPrefab, transform.position, Quaternion.identity) as GameObject;
								ScheduledFire scheduledFire = enemy.GetComponent<ScheduledFire> ();
								scheduledFire.m_fireFrequencySeconds *= m_dicfficulty_level;
						}
						m_dicfficulty_level ++;
				}
		}
	
		void OnDrawGizmos ()
		{
				Gizmos.color = Color.cyan;
				Gizmos.DrawCube (transform.position, Vector3.one * 2f);
		}


}
