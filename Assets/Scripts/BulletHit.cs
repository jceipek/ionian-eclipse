using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{
	public float m_health = 100f;

	public void GetHit (float damage)
	{
		m_health -= damage;
		if (m_health <= 0) {
			Destroy (gameObject);
		}
	}
}