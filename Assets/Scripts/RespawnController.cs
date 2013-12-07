using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent (typeof(Health))]
public class RespawnController : MonoBehaviour
{
	public float m_startingRespawnTime;
	public float m_maxRespawnTime;
	private Dictionary<string, float> m_respawnTimeMap = new Dictionary<string, float> ();

	public void Respawn (string shipName)
	{
		if (m_respawnTimeMap.ContainsKey (shipName)) {
			m_respawnTimeMap [shipName] *= 2;
			m_respawnTimeMap [shipName] = Mathf.Min (m_respawnTimeMap [shipName], m_maxRespawnTime);
		} else {
			m_respawnTimeMap [shipName] = m_startingRespawnTime;
		}
		StartCoroutine (RespawnInTime (shipName, m_respawnTimeMap [shipName]));
	}

	IEnumerator RespawnInTime (string shipName, float respawnTime)
	{
		yield return new WaitForSeconds (respawnTime);
		Instantiate (Resources.Load (shipName), transform.position, Quaternion.identity);
	}
}