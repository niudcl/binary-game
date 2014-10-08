/***************************************
 * 
 * 	InputManager
 * 
 * 	Manages player button input and value.
 * 
 * ************************************/
using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	private BitArray rawInput;		// player button status
	private int value;		// player's value
	private float uiUnit;		// unit for scaling ui
	private float uiStart;		// button ui starting point
	private GUIStyle style;		// style for button text
	
	public Font font;		// font for button text
	public Texture2D OffTex;		// button off texture 
	public Texture2D OnTex;		// button on texture
	public int Value {
		get { return value; }
	}

	private void Start () {
		// setup buttons
		rawInput = new BitArray(6);
		value = ToInt (rawInput);

		// scale ui to screen
		uiUnit = Screen.height / 5.0f;
		uiStart = (Screen.width / 2.0f) - (uiUnit * 3.0f);

		// setup style for button text
		style = new GUIStyle();
		style.font = font;
		style.fontSize = (int)(0.11f * Screen.height);
		style.alignment = TextAnchor.MiddleCenter;
	}

	private void Update () {
		// player buttons
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
	}

	private void OnGUI () {
		// draw buttons
		for (var i = 0; i < 6; i++) {
			GUI.Label(new Rect(uiStart + i * uiUnit, Screen.height - uiUnit, uiUnit, uiUnit), 
			          (rawInput[i]) ? OnTex : OffTex);
			GUI.Label(new Rect(uiStart + i * uiUnit, Screen.height - uiUnit, uiUnit, uiUnit),
			          (1 << (5 - i)).ToString(), style);
		}
	}

	// convert boolean array to a 6 bit number
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
