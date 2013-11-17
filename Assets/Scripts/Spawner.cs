using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

	public GameObject m_enemyPrefab;
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
				Instantiate (m_enemyPrefab, transform.position, Quaternion.identity);
			}

		}
	}
	
	void OnDrawGizmos ()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawCube (transform.position, Vector3.one * 2f);
	}
}
