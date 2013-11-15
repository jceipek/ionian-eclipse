using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

	public GameObject m_enemyPrefab;

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
			yield return (new WaitForSeconds (2f));
			Instantiate (m_enemyPrefab, transform.position, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}
}
