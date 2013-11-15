using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour
{
	public float m_speed = 10f;
	public float m_castOriginOffset = 0.9f;
	private Vector3 m_previousPosition;

	// Use this for initialization
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

	// Update is called once per frame
	void FixedUpdate ()
	{
		RaycastHit2D hit = Physics2D.Linecast (m_previousPosition, transform.position + transform.up * (Time.fixedDeltaTime * m_speed));
		if (hit.collider) {
			GameObject hitObject = hit.collider.gameObject;
			BulletHit bulletHit = hitObject.GetComponent<BulletHit> ();
			if (bulletHit) {
				bulletHit.GetHit (10f);
				Destroy (gameObject);
			}
		}

		transform.position += transform.up * Time.fixedDeltaTime * m_speed;
		m_previousPosition = transform.position;
	}
}
