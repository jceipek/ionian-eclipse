using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour
{

	public Transform m_gunPos;
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
		if (Input.GetButtonDown ("Fire")) {
			Instantiate (m_bullet, m_gunPos.position, transform.rotation);
		}
	}
}
