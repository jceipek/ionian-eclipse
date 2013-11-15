using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour
{
	public float m_speed = 10f;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (Die (1f));
	}

	IEnumerator Die (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		Destroy (gameObject);
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		RaycastHit2D hit = Physics2D.Raycast (transform.position - transform.up * (Time.fixedDeltaTime * m_speed), transform.up, Time.fixedDeltaTime * m_speed);
		if (hit.collider) {
			GameObject hitObject = hit.collider.gameObject;
			BulletHit bulletHit = hitObject.GetComponent<BulletHit> ();
			if (bulletHit) {
				Debug.Log ("HIT");
				bulletHit.GetHit ();
			}
//			Destroy (gameObject);
		}

		transform.position += transform.up * Time.fixedDeltaTime * m_speed;
	}

}
