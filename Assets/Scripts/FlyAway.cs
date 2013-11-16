using UnityEngine;
using System.Collections;

public class FlyAway : MonoBehaviour
{
	private Vector3 m_direction;
	private float m_force = 30f;

	void Start ()
	{
		StartCoroutine (Die (1f));
	}

	public void InitWithDirection (Vector3 direction)
	{
		m_direction = direction.normalized;
	}

	// We don't need to do this in FixedUpdate because this is for non-interactive, non physics objects
	void Update ()
	{
		transform.position += m_direction * m_force * Time.deltaTime;
	}
	
	IEnumerator Die (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		Destroy (gameObject);
	}
}