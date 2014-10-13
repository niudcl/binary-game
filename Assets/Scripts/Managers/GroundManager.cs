/***************************************
 * 
 * 	GroundManager
 * 
 * 	Controls the creation and updating
 * 	of the ground.
 * 	
 * 	Requires: 	DoorManager 	(class)
 * 
 * ************************************/
using UnityEngine;
using System.Collections;

public class GroundManager : MonoBehaviour {

	private float speed;		// speed taken from DoorManager
	private int size = 100;		// length of ground
	private GameObject[] gObjs = new GameObject[2];		// ground objects

	public GameObject Ground;		// ground prefab

	void Start () {
		// get speed from DoorManager
		speed = GameObject.FindObjectOfType<DoorManager>().Speed;

		// build ground objects
		for (int i = 0; i < 2; i++) {
			gObjs[i] = (GameObject)Instantiate(Ground,
			                                  Vector3.right * (size * i),
			                                  Quaternion.identity);
			gObjs[i].GetComponent<GroundMover>().Speed = speed;
		}
	}

	void Update () {
		// wraparound ground objects
		if (gObjs[0].transform.position.x < -size) {
			gObjs[0].transform.Translate(Vector3.right * (2 * size));
		} else if (gObjs[1].transform.position.x < -size) {
			gObjs[1].transform.Translate(Vector3.right * (2 * size));
		}
	}

}
