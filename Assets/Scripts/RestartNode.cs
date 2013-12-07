using UnityEngine;
using System.Collections;

public class RestartNode : MonoBehaviour
{
		private bool m_restartable;
		void Start ()
		{
				m_restartable = false;
				StartCoroutine (AllowRestart ());
		}
		void Restart ()
		{
				Application.LoadLevel ("mothershipTest");
		}
		IEnumerator AllowRestart ()
		{
				yield return new WaitForSeconds (3f);
				m_restartable = true;
		}
		void Update ()
		{
				if (Input.anyKey && m_restartable) {
						Restart ();
				}
		}
}
