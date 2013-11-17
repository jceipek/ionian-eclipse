using UnityEngine;
using System.Collections;

public class FireAbility : MonoBehaviour
{
	public Transform[] m_gunPos;
	public Color m_bulletColor = Color.white;
	public float m_bulletSpeed = 100f;
	public float m_bulletForce = 1000f;
	public float m_bulletDamage = 1f;
	public float m_cooldownSeconds = 0.1f;
	private bool m_canShoot = true;
	private GameObject m_bullet;
		
	void OnEnable ()
	{
		m_bullet = Resources.Load ("Bullet") as GameObject;
	}
		
	public void Fire ()
	{
		if (!m_canShoot) {
			return;
		}
		foreach (var gunTransform in m_gunPos) {
			GameObject bullet = Instantiate (m_bullet, gunTransform.position, transform.rotation) as GameObject;
			bullet.GetComponent<Fly> ().Init (m_bulletColor,
			                                  speed: m_bulletSpeed,
			                                  force: m_bulletForce,
			                                  damage: m_bulletDamage);
		}

		m_canShoot = false;
		StartCoroutine (CoolDown ());
	}

	IEnumerator CoolDown ()
	{
		yield return new WaitForSeconds (m_cooldownSeconds);
		m_canShoot = true;
	}
}