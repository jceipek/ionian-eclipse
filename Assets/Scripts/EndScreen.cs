using UnityEngine;
using System.Collections;

public class EndScreen : MonoBehaviour
{
		public static void Win ()
		{
				Application.LoadLevel ("Win");
		}
		public static void Lose ()
		{
				Application.LoadLevel ("Lose");
		}
		public void DetermineEnd (bool win)
		{
				if (win) {
						Application.LoadLevel ("Win");
				} else {
						Application.LoadLevel ("Lose");
				}
				//Instantiate (Resources.Load (shipName), transform.position, Quaternion.identity);
		}
}
