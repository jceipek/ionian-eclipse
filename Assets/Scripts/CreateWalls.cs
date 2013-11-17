using UnityEngine;
using System.Collections;

public class CreateWalls : MonoBehaviour
{

	void Start ()
	{
		float wallWidth = 1f;
		Vector3 max = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		Vector3 min = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		float width = max.x - min.x;
		float height = max.y - min.y;

		Vector3[] positions = new Vector3[4] {
			new Vector3 (min.x - wallWidth / 2, 0, 0),
			new Vector3 (max.x + wallWidth / 2, 0, 0),
			new Vector3 (0, min.y - wallWidth / 2, 0),
			new Vector3 (0, max.y + wallWidth / 2, 0)
		};

		Vector2[] dimensions = new Vector2[4] {
			new Vector2 (wallWidth, height + 2 * wallWidth),
			new Vector2 (wallWidth, height + 2 * wallWidth),
			new Vector2 (width + 2 * wallWidth, wallWidth),
			new Vector2 (width + 2 * wallWidth, wallWidth)
		};

		for (int i = 0; i < 4; i++) {
			GameObject wall = new GameObject ();
			BoxCollider2D wallCollider = wall.AddComponent<BoxCollider2D> ();
			wall.transform.position = positions [i];
			wall.transform.parent = transform;
			wallCollider.size = dimensions [i];
		}
	}
}
