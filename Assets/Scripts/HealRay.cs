using UnityEngine;
using System.Collections;

public class HealRay : MonoBehaviour
{
	private LineRenderer m_lineRenderer;
	private Transform m_start;
	private Transform m_end;

	// Use this for initialization
	void OnEnable ()
	{
		m_lineRenderer = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Start ()
	{
		StartCoroutine (Die (0.3f));
	}

	void Update ()
	{
		if (m_start != null && m_end != null) {
			m_lineRenderer.SetPosition (0, m_start.position);
			m_lineRenderer.SetPosition (1, m_end.position);
		}

	}

	public void SetPosition (Transform start, Transform end)
	{
		m_start = start;
		m_end = end;
	}

	IEnumerator Die (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		Destroy (gameObject);
	}
}
