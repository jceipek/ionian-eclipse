using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MoveToDest))]
public class PointerControlDest : MonoBehaviour
{
	public MoveToDest m_moveToDest;

	// Use this for initialization
	void OnEnable ()
	{
		m_moveToDest = GetComponent<MoveToDest> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 pos = (Camera.main.ScreenPointToRay (Input.mousePosition)).origin;
		m_moveToDest.SetDest (pos);
	}
}
