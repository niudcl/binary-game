using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private TextMesh tm;
	private int num;
	private Vector3 tmOffset = new Vector3(-0.5f, 0.0f, 0.0f);

	public GameObject Player;
	public TextMesh TmPrefab;
	public bool ShouldUpdate;
	public int Num {
		get { return num; }
		set { num = value; }
	}

	void Awake () {
		tm = (TextMesh)Instantiate(TmPrefab, 
		                           transform.position + tmOffset, 
		                           Quaternion.identity);
	}

	void Start () {
		tm.text = num.ToString();
	}
	
	
	void Update () {
		tm.transform.position = Player.transform.position + Vector3.up;

		if (ShouldUpdate) {
			tm.text = num.ToString();
		}
	}

}
