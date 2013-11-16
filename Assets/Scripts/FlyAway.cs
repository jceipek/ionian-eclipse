using UnityEngine;
using System.Collections;

public class FlyAway : MonoBehaviour
{
	private Vector3 m_direction;
	private float m_force = 100f;
	private SpriteRenderer m_renderer;

	void OnEnable ()
	{
		m_renderer = GetComponent<SpriteRenderer> ();
	}

	public void InitWithDirectionAndTime (Vector3 direction, float seconds)
	{
		StartCoroutine (Die (seconds));
		m_direction = direction.normalized;
	}

	// We don't need to do this in FixedUpdate because this is for non-interactive, non physics objects
	void Update ()
	{
		transform.position += m_direction * m_force * Time.deltaTime;
	}
	
	IEnumerator Die (float seconds)
	{
		float total = seconds;
		float delta = 0.01f;
		while (total > 0) {
			yield return new WaitForSeconds (delta);
			total -= delta;
			Color color = m_renderer.color;
			color.a = total / seconds;
			m_renderer.color = color;
		}
		Destroy (gameObject);
	}
}