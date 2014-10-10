using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	private int hScore;

	public int HScore {
		get { return hScore; }
		set { hScore = value; }
	}

	private void Start () {
		DontDestroyOnLoad(gameObject);
	}
}
