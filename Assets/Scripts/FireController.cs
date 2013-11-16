using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour
{

	public string m_fireButton;
	public bool m_fireButtonIsAxis;
	public Transform[] m_gunPos;
	private GameObject m_bullet;

	void OnEnable ()
	{
		m_bullet = Resources.Load ("Bullet") as GameObject;
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool fireButton = !m_fireButtonIsAxis && Input.GetButtonDown (m_fireButton);
		bool fireAxis = m_fireButtonIsAxis && (Input.GetAxis (m_fireButton) > 0.1f);
		if (fireButton || fireAxis) {
			foreach (var gunTransform in m_gunPos) {
				Instantiate (m_bullet, gunTransform.position, transform.rotation);
			}
		}
	}
}
