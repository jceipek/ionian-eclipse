using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	public float m_initialHealth = 100f;
	private float m_health;
	private GameObject m_shardPrefab;

	void OnEnable ()
	{
		m_shardPrefab = Resources.Load ("Shard") as GameObject;
		m_health = m_initialHealth;
	}

	void Update ()
	{
		if (m_health <= 0) {
			StartCoroutine (Die ());
		}
	}

	public float ChangeHealthBy (float delta)
	{
		m_health += delta;
		return m_health;
	}

	
	IEnumerator Die ()
	{
		yield return new WaitForSeconds (0.5f);
		for (var i = 0; i < 5; i++) {
			Vector3 direction = Random.insideUnitCircle;
			GameObject shard = Instantiate (m_shardPrefab, transform.position + direction, Quaternion.identity) as GameObject;
			FlyAway flyAway = shard.GetComponent<FlyAway> ();
			flyAway.InitWithDirectionAndTime (direction, 10f);
		}
		Destroy (gameObject);
	}

	public float GetHealthRatio ()
	{
		return m_health / m_initialHealth;
	}


	
}
