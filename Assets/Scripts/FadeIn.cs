using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	private float time = 1.0f;
	private float startTime;
	public Texture2D fill;

	void Awake () {
		startTime = Time.time;
	}

	void OnGUI () {
		float percent = (Time.time - startTime) / time;
		if (percent > 1.0f) {
			Destroy (gameObject);
		} else {
			Color c = new Color(1.0f, 1.0f, 1.0f, 1.0f - percent);
			GUI.color = c;
			GUI.DrawTexture(new Rect(0.0f, 0.0f, Screen.width, Screen.height), fill);
		}
	}
}
