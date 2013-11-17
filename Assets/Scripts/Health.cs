using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	public float m_initialHealth = 100f;
	private float m_health;

	private GameObject m_shardPrefab;
	
	private RespawnAbility m_respawnAbility;

	void OnEnable ()
	{
		m_shardPrefab = Resources.Load ("Shard") as GameObject;
		m_health = m_initialHealth;
		m_respawnAbility = GetComponent<RespawnAbility> ();
	}

	public float ChangeHealthBy (float delta)
	{
		m_health += delta;
		if (m_health > m_initialHealth) {
			m_health = m_initialHealth;
		}
		if (m_health <= 0) {
			StartCoroutine (Die ());
		}
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

		if (m_respawnAbility) {
			m_respawnAbility.Respawn ();
		}

	}

	public float GetHealthRatio ()
	{
		return m_health / m_initialHealth;
	}

	public float GetHealth ()
	{
		return m_health;
	}

	public float GetStartHealth ()
	{
		return m_initialHealth;
	}

}
