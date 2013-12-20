using UnityEngine;
using System.Collections;

public class RestartNode : MonoBehaviour
{
	public float m_timeTillCanRestart = 1.0f;
	public string mainLevel = "Main";
	private bool m_restartable;
	private SpriteRenderer m_spriteRenderer;
	private float m_counter = 0.0f;
	void Start ()
	{
		m_spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		Color color = m_spriteRenderer.color;
		color.a = 0.0f;
		m_spriteRenderer.color = color;
		m_restartable = false;
		StartCoroutine (AllowRestart ());
	}
	void Restart ()
	{
		Application.LoadLevel (mainLevel);
	}

	IEnumerator AllowRestart ()
	{
		yield return new WaitForSeconds (m_timeTillCanRestart);
		m_restartable = true;
		Color color = m_spriteRenderer.color;
		color.a = 1.0f;
		m_spriteRenderer.color = color;
	}
	void Update ()
	{
		m_counter += Time.deltaTime;
		m_counter %= 1000f;
		transform.localScale = Vector3.one * 0.5f + (Vector3.one * Mathf.PingPong (m_counter, 0.3f) * 0.25f);
		if (Input.anyKey && m_restartable) {
			Restart ();
		}
	}
}
