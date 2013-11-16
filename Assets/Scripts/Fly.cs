using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour
{
	public float m_speed = 10f;
	public float m_force = 1000f;
	private Vector3 m_previousPosition;
	private RaycastHit2D[] m_linecastResults = new RaycastHit2D[1]; // For efficient caching
	
	void Start ()
	{
		StartCoroutine (Die (1f));
		m_previousPosition = transform.position;
	}

	IEnumerator Die (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		Destroy (gameObject);
	}
	
	void FixedUpdate ()
	{
		int hitCount = Physics2D.LinecastNonAlloc (m_previousPosition, transform.position + transform.up * (Time.fixedDeltaTime * m_speed), m_linecastResults);
		for (int i = 0; i < hitCount; i++) {
			RaycastHit2D hit = m_linecastResults [i];
			if (hit.collider) {
				GameObject hitObject = hit.collider.gameObject;
				BulletHit bulletHit = hitObject.GetComponent<BulletHit> ();
				if (bulletHit) {
					bulletHit.GetHit (10f, transform.up * m_force);
					Destroy (gameObject);
				}
			}
		}

		transform.position += transform.up * Time.fixedDeltaTime * m_speed;
		m_previousPosition = transform.position;
	}
}
