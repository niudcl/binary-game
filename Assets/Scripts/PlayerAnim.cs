using UnityEngine;
using System.Collections;

public class PlayerAnim : MonoBehaviour {

	private float speed = 180.0f;
	public float Speed {
		get { return speed; }
		set { speed = value; }
	}

	private void Update () {
		transform.position = new Vector3(transform.position.x,
		                                 Mathf.Sin(Time.time * 2.0f),
		                                 Mathf.Sin(Time.time));
		transform.Rotate(Vector3.forward * speed * Time.deltaTime);
	}
}
