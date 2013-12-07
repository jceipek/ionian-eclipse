using UnityEngine;
using System.Collections;

public class TeleporterController : MonoBehaviour
{
	public string[] m_controlAxis = new string[2];
	public string[] m_shadowControlAxis = new string[2];
	public bool m_teleportButtonIsAxis;
	public string m_teleportButton;
	public MoveBehavior m_moveBehavior;
	public MoveBehavior m_shadowMoveBehavior;
	public float m_teleportCooldownSeconds;

	private Rigidbody2D m_rigidbody;
	private bool m_canTeleport = true;
	
	void FixedUpdate ()
	{
		float horizontal = Input.GetAxis (m_controlAxis [0]);
		float vertical = Input.GetAxis (m_controlAxis [1]);
		
		float shadowHorizontal = Input.GetAxis (m_shadowControlAxis [0]);
		float shadowVertical = Input.GetAxis (m_shadowControlAxis [1]);

		bool teleportButton = !m_teleportButtonIsAxis && Input.GetButtonDown (m_teleportButton);
		bool teleportAxis = m_teleportButtonIsAxis && (Input.GetAxis (m_teleportButton) > 0.1f);

		if (teleportButton || teleportAxis) {
			Teleport ();
		}

		m_moveBehavior.Move (horizontal, -vertical);
		m_shadowMoveBehavior.Move (shadowHorizontal, -shadowVertical);
		

		//m_rigidbody.AddTorque (GetTorque (transform.up, (new Vector3 (lookVertical, -lookHorizontal)).normalized));

		//"L_YAxis_1"
	}

	IEnumerator CoolDown ()
	{
		yield return new WaitForSeconds (m_teleportCooldownSeconds);
		m_canTeleport = true;
	}

	void Teleport ()
	{
		if (!m_canTeleport) {
			return;
		}

		m_canTeleport = false;

		var oldPos = m_moveBehavior.transform.position;
		var newPos = m_shadowMoveBehavior.transform.position;
		
		m_moveBehavior.transform.position = newPos;
		m_shadowMoveBehavior.transform.position = oldPos;
		StartCoroutine (CoolDown ());
	}
	
}