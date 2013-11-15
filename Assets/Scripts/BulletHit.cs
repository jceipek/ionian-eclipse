using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{

	public void GetHit ()
	{
		Destroy (gameObject);
	}
}