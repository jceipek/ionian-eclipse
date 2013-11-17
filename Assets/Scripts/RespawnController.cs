using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Health))]
public class RespawnController : MonoBehaviour
{
	public float m_respawnTime;

	public void Respawn (string shipName)
	{
		StartCoroutine (RespawnInTime (shipName));
	}
	IEnumerator RespawnInTime (string shipName)
	{
		yield return new WaitForSeconds (m_respawnTime); 
		Instantiate (Resources.Load (shipName), transform.position, Quaternion.identity);
	}
		
}