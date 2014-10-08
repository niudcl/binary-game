using UnityEngine;
using System.Collections;

public class GroundMover : MonoBehaviour {

	private float speed;

	public DoorManager dm;

	void Start () {
		speed = dm.GetSpeed();
	}

	void Update () {
		transform.Translate(new Vector3(speed * Time.deltaTime, 0.0f, 0.0f));
	}
}
