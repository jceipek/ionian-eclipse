using UnityEngine;
using System.Collections;

public class Spawner_VariableDifficulty : MonoBehaviour
{
	public GameObject m_enemyPrefab;
	public int m_difficulty_level = 1;
	//TODO: Change to be dependant on time since game has started
	public float m_spawningRate; 
	public int m_enemyCountPerSpawn = 1;
	public float m_maxShootingFrequency = 0.1f;

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
				Health health = enemy.GetComponent<Health> ();
				FireAbility fireAbility = enemy.GetComponent<FireAbility> ();
				if (m_difficulty_level % 5 == 0) {
					if (scheduledFire.m_fireFrequencySeconds < m_maxShootingFrequency) {
						scheduledFire.m_fireFrequencySeconds = (3 / m_difficulty_level);
					} else {
						scheduledFire.m_fireFrequencySeconds = m_maxShootingFrequency;
					}
				}
				//Change damage and size of bullets.
				/*if (m_difficulty_level % 8 == 0) {
										fireAbility.m_gunPos
								}*/
				if (m_difficulty_level % 2 == 0) {
					health.m_initialHealth *= 2f;	
					//Also change enemy color ?	
				}
				//After 18th enemy enemies become fast
				//if(m_difficulty_level> 19){
			}
			m_difficulty_level ++;
		}
	}
	
	void OnDrawGizmos ()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawCube (transform.position, Vector3.one * 2f);
	}


}
