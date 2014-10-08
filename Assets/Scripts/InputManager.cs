using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	private BitArray rawInput;
	private int value;
	private float uiUnit;
	private float uiStart;
	private GUIStyle style;

	public PlayerManager pm;
	public Font font;
	public Texture2D OffTex;
	public Texture2D OnTex;
	public int Value {
		get { return value; }
	}

	void Start () {
		rawInput = new BitArray(6);
		value = ToInt (rawInput);

		uiUnit = Screen.height / 5.0f;
		uiStart = (Screen.width / 2.0f) - (uiUnit * 3.0f);

		style = new GUIStyle();
		style.font = font;
		style.fontSize = (int)(0.11f * Screen.height);
		style.alignment = TextAnchor.MiddleCenter;
	}

	void Update () {
		if (Input.GetButtonDown("Button0")) {
			rawInput[0] = (rawInput[0]) ? false : true;
		}
		if (Input.GetButtonDown("Button1")) {
			rawInput[1] = (rawInput[1]) ? false : true;
		}
		if (Input.GetButtonDown("Button2")) {
			rawInput[2] = (rawInput[2]) ? false : true;
		}
		if (Input.GetButtonDown("Button3")) {
			rawInput[3] = (rawInput[3]) ? false : true;
		}
		if (Input.GetButtonDown("Button4")) {
			rawInput[4] = (rawInput[4]) ? false : true;
		}
		if (Input.GetButtonDown("Button5")) {
			rawInput[5] = (rawInput[5]) ? false : true;
		}
		value = ToInt(rawInput);
		pm.Num = value;
	}

	void OnGUI () {
		for (var i = 0; i < 6; i++) {
			GUI.Label(new Rect(uiStart + i * uiUnit, Screen.height - uiUnit, uiUnit, uiUnit), 
			          (rawInput[i]) ? OnTex : OffTex);
			GUI.Label(new Rect(uiStart + i * uiUnit, Screen.height - uiUnit, uiUnit, uiUnit),
			          (1 << (5 - i)).ToString(), style);
		}
	}

	private int ToInt (BitArray ba) {
		int val = 0;
		for (var i = 0; i < 6; i++) {
			if (ba[i]) {
				val += 1 << (5 - i);
			}
		}
		return val;
	}
}
