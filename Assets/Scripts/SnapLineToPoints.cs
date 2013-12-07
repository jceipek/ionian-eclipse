using UnityEngine;
using System.Collections;

[RequireComponent (typeof(LineRenderer))]
public class SnapLineToPoints : MonoBehaviour
{

	private LineRenderer m_lineRenderer;
	public Transform[] m_points = new Transform[2];

	void OnEnable ()
	{
		m_lineRenderer = GetComponent<LineRenderer> ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector2[] points = {m_points [0].position, m_points [1].position};
		m_lineRenderer.SetPosition (0, points [0]);
		m_lineRenderer.SetPosition (1, points [1]);
	}
}
