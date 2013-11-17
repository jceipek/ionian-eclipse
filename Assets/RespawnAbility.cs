using UnityEngine;
using System.Collections;

[RequireComponent (typeof(PlayerType))]
public class RespawnAbility : MonoBehaviour
{
	private RespawnController m_respawner;

	// Use this for initialization
	void Start ()
	{
		m_respawner = GameObject.FindGameObjectWithTag ("Respawn").GetComponent<RespawnController> ();
	}

	public void Respawn ()
	{
		string playerType = GetComponent<PlayerType> ().m_type;
		m_respawner.gameObject.SendMessage ("Respawn", playerType);
	}
}
