using UnityEngine;
using System.Collections;

public class Spawner_VariableDifficulty : MonoBehaviour
{
	public GameObject m_enemyPrefab;
	private int m_difficultyLevel = 1;
	public float m_spawningFrequency = 20; 
	public int m_enemyCountPerSpawn = 1;

	public float m_maxFireFrequency = 0.1f;
	public float m_minFireFrequency = 1f;

	public float m_maxDamage = 10f;
	public float m_minDamage = 1f;

	public float m_maxSpeed = 50f;
	public float m_minSpeed = 5f;

	public float m_maxHealth = 200f;
	public float m_minHealth = 3f;

	public float m_maxBulletSize = 4f;
	public float m_maxEnemySize = 4f;

	private float m_gameLength;

	void OnEnable ()
	{
		m_enemyPrefab = Resources.Load ("Enemy") as GameObject;
	}
	
	void Start ()
	{
		m_gameLength = GameTimer.g.m_gameLength;
		StartCoroutine (Spawn ());	
	}
	
	IEnumerator Spawn ()
	{
		while (true) {
			float time = GameTimer.g.getTime ();
			float damage = damageFromTime (time);
			float health = healthFromTime (time);
			float speed = speedFromTime (time);
			float fireFrequency = fireFrequencyFromTime (time);
			Debug.Log ("spawn " + time);

			for (int i = 0; i < m_enemyCountPerSpawn; i++) {
				CreateEnemy (damage, health, speed, fireFrequency);
			}
			m_difficultyLevel ++;
			yield return (new WaitForSeconds (m_spawningFrequency));
		}
	}

	private void CreateEnemy (float damage, float health, float speed, float fireFrequency, float size = 0f, float bulletSize = 0f)
	{
		GameObject enemy = Instantiate (m_enemyPrefab, transform.position, Quaternion.identity) as GameObject;

		ScheduledFire scheduledFire = enemy.GetComponent<ScheduledFire> ();
		MoveToDest movement = enemy.GetComponent<MoveToDest> ();
		Health healthComponent = enemy.GetComponent<Health> ();
		FireAbility fireAbility = enemy.GetComponent<FireAbility> ();

		if (size == 0f) {
			size = enemySizeFromHealth (health);
		}
		if (bulletSize == 0f) {
			bulletSize = bulletSizeFromDamage (damage);
		}

		enemy.transform.localScale = size * Vector3.one;
		fireAbility.m_bulletSize = bulletSize;
		fireAbility.m_bulletDamage = damage;
		scheduledFire.m_fireFrequencySeconds = fireFrequency;
		movement.m_linearForce = speed;
		healthComponent.Init (health);
	}



	private float fireFrequencyFromTime (float time)
	{
		return Mathf.Lerp (m_minFireFrequency, m_maxFireFrequency, (time / m_gameLength));
	}

	private float healthFromTime (float time)
	{
		return Mathf.Lerp (m_minHealth, m_maxHealth, (time / m_gameLength));
	}

	private float damageFromTime (float time)
	{
		return Mathf.Lerp (m_minDamage, m_maxDamage, (time / m_gameLength));
	}

	private float speedFromTime (float time)
	{
		return Mathf.Lerp (m_minSpeed, m_maxSpeed, (time / m_gameLength));
	}

	private float enemySizeFromHealth (float health)
	{
		float ratio = Mathf.InverseLerp (m_minHealth, m_maxHealth, health);
		return Mathf.Lerp (1f, m_maxBulletSize, ratio);
	}

	private float bulletSizeFromDamage (float damage)
	{
		float ratio = Mathf.InverseLerp (m_minDamage, m_maxDamage, damage);
		return Mathf.Lerp (1f, m_maxBulletSize, ratio);
	}
	
	void OnDrawGizmos ()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawCube (transform.position, Vector3.one * 2f);
	}


}
