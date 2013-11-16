using UnityEngine;
using System.Collections;

public class FireAbility : MonoBehaviour
{
	public Transform[] m_gunPos;
	private GameObject m_bullet;
		
	void OnEnable ()
	{
		m_bullet = Resources.Load ("Bullet") as GameObject;
	}
		
	public void Fire ()
	{
		foreach (var gunTransform in m_gunPos) {
			Instantiate (m_bullet, gunTransform.position, transform.rotation);
		}
	}
}