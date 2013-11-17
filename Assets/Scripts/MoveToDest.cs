using UnityEngine;
using System.Collections;

public class MoveToDest : MonoBehaviour
{
	public Vector2 m_destination;
	public float m_torqueForce;
	public float m_linearForce;
	public float m_distanceOffset;
	public float m_followDistance = 3f;
	public float m_lookaheadDistance = 1.0f;
	private RaycastHit2D[] m_linecastResult = new RaycastHit2D[1]; // For efficient caching
	private Rigidbody2D m_rigidbody;


	void OnEnable ()
	{
		m_rigidbody = GetComponent<Rigidbody2D> ();
	}

	void Start ()
	{
		StartCoroutine (LowFrequencyUpdater ());
	}

	public void SetDest (Vector2 dest)
	{
		m_destination = dest;
	}
	

	private float GetTorque (Vector3 fwd, Vector3 targetDir)
	{
		var angle = Vector3.Angle (fwd, targetDir);
		Vector3 perp = Vector3.Cross (fwd, targetDir);
		int direction = (int)perp.normalized.z;
		return m_torqueForce * angle * direction;
	}

	void Move ()
	{
		Vector3 dest = m_destination;

		Vector3 vec = dest - transform.position;
		float torque = GetTorque (transform.up, vec.normalized);

		if (vec.sqrMagnitude > m_distanceOffset * m_distanceOffset) {
			m_rigidbody.AddForce (vec.normalized * m_linearForce);
		} else {
			m_rigidbody.AddForce (-vec.normalized * m_linearForce);
		}

		if (vec.magnitude > 1) {
			m_rigidbody.AddTorque (torque);
		}
	}
	
	void BufferLogic ()
	{
		int hitCount = Physics2D.LinecastNonAlloc (transform.up * m_lookaheadDistance + transform.position, transform.position + transform.up * m_followDistance, m_linecastResult);
		if (hitCount > 0) {
			m_distanceOffset = (transform.position - (Vector3)m_linecastResult [0].point).magnitude + ((Vector3)m_destination - transform.position).magnitude;
		}
	}

	void FixedUpdate ()
	{
		Move ();
	}

	IEnumerator LowFrequencyUpdater ()
	{
		while (true) {
			yield return new WaitForSeconds (0.1f);
			BufferLogic ();
		}
	}
}