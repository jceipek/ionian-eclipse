using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MoveToDest))]
public class gameController : MonoBehaviour
{
		public MoveToDest m_moveToDest;
/*
		private bool connected = false;
		IEnumerator CheckForControllers ()
		{
				while (true) {
						var controllers = Input.GetJoystickNames ();
						if (!connected && controllers.Length > 0) {
								connected = true;
								Debug.Log ("Connected");
						} else if (connected && controllers.Length == 0) {
								connected = false;
								Debug.Log ("Disconnected");
						}
						yield return new WaitForSeconds (1f);
				}
		}
		void Awake ()
		{
				StartCoroutine (CheckForControllers ());
		}
	*/
		// Use this for initialization
		void OnEnable ()
		{
				m_moveToDest = GetComponent<MoveToDest> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				float horiz = Input.GetAxis ("Horizontal");
				float vert = Input.GetAxis ("Vertical");
				Vector2 newPos = new Vector2 (transform.position.x + horiz, transform.position.y + vert);
				Debug.DrawLine (transform.position, (new Vector3 (newPos.x, newPos.y, 0)));
				m_moveToDest.SetDest (newPos);
		}
}