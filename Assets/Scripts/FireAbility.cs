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
	public Transform m_turretPos;
	private bool m_canShoot = true;
	private GameObject m_bullet;
		
	void OnEnable ()
	{
		m_bullet = Resources.Load ("Bullet") as GameObject;
	}
		
	public void Fire (Vector3? direction = null)
	{
		Quaternion rotation;
		if (direction != null && m_turretPos) {
			Vector3 vecDirection = (Vector3)direction;
			float angle = Mathf.Rad2Deg * Mathf.Atan2 (vecDirection [0], vecDirection [1]);
			m_turretPos.rotation = Quaternion.Euler (0, 0, angle + 180);
			rotation = m_turretPos.rotation;
		} else {
			rotation = transform.rotation;
		}

		if (!m_canShoot) {
			return;
		}
		foreach (var gunTransform in m_gunPos) {

			GameObject bullet = Instantiate (m_bullet, gunTransform.position, rotation) as GameObject;
			bullet.GetComponent<Fly> ().Init (m_bulletColor,
			                                  speed: m_bulletSpeed,
			                                  force: m_bulletForce,
			                                  damage: m_bulletDamage,
			                                  ship: gameObject);
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