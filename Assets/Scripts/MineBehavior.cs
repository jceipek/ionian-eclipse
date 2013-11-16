using UnityEngine;
using UnityEngine;
using System.Collections;

public class MineBehavior : MonoBehaviour
{
	public float m_force = 1000f;	
	public float m_damage = 30f;
	public GameObject m_visualRadius;
	private Collider2D[] m_overlapCircleResults = new Collider2D[20];
	void Start ()
	{
		StartCoroutine (Explode (2f));
	}
	
	IEnumerator Explode (float seconds)
	{
		float total = seconds;
		float delta = 0.01f;
		while (total > 0) {
			yield return new WaitForSeconds (delta);
			total -= delta;
			m_visualRadius.transform.localScale = Vector3.Lerp (Vector3.one * 6f, Vector3.zero, total / seconds);
		}

		CheckHit ();
		Destroy (gameObject);
	}
	
	void CheckHit ()
	{
		int hitCount = Physics2D.OverlapCircleNonAlloc ((Vector2)transform.position, 6f, m_overlapCircleResults);
		for (var i = 0; i < hitCount; i++) {
			Collider2D unfortunate = m_overlapCircleResults [i];
			if (unfortunate) {
				BulletHit bulletHit = unfortunate.GetComponent<BulletHit> ();
				if (bulletHit) {
					bulletHit.GetHit (m_damage, (transform.position - unfortunate.transform.position) * -m_force);
				}
			}
		}
	}
}