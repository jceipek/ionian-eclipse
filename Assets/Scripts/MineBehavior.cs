using UnityEngine;
using UnityEngine;
using System.Collections;

public class MineBehavior : MonoBehaviour
{
		public float m_force = 1000f;	
		private Collider2D[] m_overlapCircleResults = new Collider2D[20];
		void Start ()
		{
				StartCoroutine (Explode (2f));
		}
	
		IEnumerator Explode (float seconds)
		{
				yield return new WaitForSeconds (seconds);
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
										bulletHit.GetHit (10f, (transform.position - unfortunate.transform.position) * -m_force);
								}
						}
				}
		}
}