using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MoveToDest))]
public class gameController : MonoBehaviour
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
				float horizontal = Input.GetAxis ("Horizontal");
				float vertical = Input.GetAxis ("Vertical");
				
/*				Vector3 horizontalNew = new Vector3 (0, 0, 0);
				Vector3 verticalNew = new Vector3 (0, 0, 0);*/
				
				Debug.Log ("horizontal: " + horizontal + "vertical: " + vertical);
/*				horizontalNew = transform.right * horizontal;
				verticalNew = transform.up * vertical;*/
				Vector3 newPos = new Vector3 (horizontal, vertical, 0);
				Debug.DrawLine (new Vector3 (0, 0, 0), newPos);
		}
}