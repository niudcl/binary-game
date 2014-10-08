using UnityEngine;
using System.Collections;

public class GroundManager : MonoBehaviour {

	private float speed;
	private int size = 100;
	private GameObject[] gObjs = new GameObject[2];

	public GameObject Ground;

	void Start () {
		speed = GameObject.FindObjectOfType<DoorManager>().GetSpeed();

		for (int i = 0; i < 2; i++) {
			gObjs[i] = (GameObject)Instantiate(Ground,
			                                  Vector3.right * (size * i),
			                                  Quaternion.identity);
			gObjs[i].GetComponent<GroundMover>().Speed = speed;
		}

	}

	void Update () {
		if (gObjs[0].transform.position.x < -size) {
			gObjs[0].transform.Translate(Vector3.right * (2 * size));
		} else if (gObjs[1].transform.position.x < -size) {
			gObjs[1].transform.Translate(Vector3.right * (2 * size));
		}
	}

}
