using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	private TextMesh tm;
	private Vector3 tmOffset = new Vector3(0.0f, 3.0f, 0.0f);
	private float speed;

	public int Code;
	public TextMesh TmPrefab;


	void Awake () {
		tm = (TextMesh)Instantiate(TmPrefab, 
		                           transform.position + tmOffset, 
		                           Quaternion.identity);
		tm.transform.parent = transform;
	}

	void Start () {
		tm.text = Code.ToString();
	}

	void Update () {
		transform.Translate(new Vector3(speed * Time.deltaTime, 0.0f, 0.0f));
	}

	public void SetCode (int c) {
		Code = c;
	}

	public void SetSpeed (float s) {
		speed = s;
	}
}
