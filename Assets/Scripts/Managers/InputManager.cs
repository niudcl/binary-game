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
	private int playerValue;		// player's value
	private int playerScore;		// player's score
	private float uiUnit;		// unit for scaling ui
	private float uiStart;		// button ui starting point
	private GUIStyle buttonStyle;		// style for button text
	private GUIStyle scoreStyle;		// style for score text
	private GUIStyle hScoreStyle;		// style for high score text
	private HighScore hs;		// high score object

	public Font font;		// font for button text
	public Texture2D OffTex;		// button off texture 
	public Texture2D OnTex;		// button on texture
	public int PlayerValue {
		get { return playerValue; }
	}
	public int PlayerScore {
		get { return playerScore; }
		set { 
			playerScore = value; 
			if (playerScore > hs.HScore) {
				hs.HScore = playerScore;
			}
		}
	}

	private void Start () {
		// find high score
		hs = GameObject.FindObjectOfType<HighScore>();

		// setup buttons
		rawInput = new BitArray(6);
		playerValue = ToInt (rawInput);

		playerScore = 0;

		// scale ui to screen
		uiUnit = Screen.height / 5.0f;
		uiStart = (Screen.width / 2.0f) - (uiUnit * 3.0f);

		// setup style for button text
		buttonStyle = new GUIStyle();
		buttonStyle.font = font;
		buttonStyle.fontSize = (int)(0.11f * Screen.height);
		buttonStyle.alignment = TextAnchor.MiddleCenter;

		scoreStyle = new GUIStyle();
		scoreStyle.font = font;
		scoreStyle.fontSize = (int)(0.06f * Screen.height);
		scoreStyle.alignment = TextAnchor.UpperLeft;
		scoreStyle.normal.textColor = Color.cyan;

		hScoreStyle = new GUIStyle();
		hScoreStyle.font = font;
		hScoreStyle.fontSize = (int)(0.06f * Screen.height);
		hScoreStyle.alignment = TextAnchor.UpperRight;
		hScoreStyle.normal.textColor = Color.cyan;
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
		playerValue = ToInt(rawInput);
	}

	private void OnGUI () {
		// draw buttons
		for (var i = 0; i < 6; i++) {
			GUI.Label(new Rect(uiStart + i * uiUnit, Screen.height - uiUnit, uiUnit, uiUnit), 
			          (rawInput[i]) ? OnTex : OffTex);
			GUI.Label(new Rect(uiStart + i * uiUnit, Screen.height - uiUnit, uiUnit, uiUnit),
			          (1 << (5 - i)).ToString(), buttonStyle);
		}
		GUI.Label(new Rect(0, 0, uiUnit * 2.0f, uiUnit), 
		          "SCORE " + playerScore.ToString(), scoreStyle);
		GUI.Label(new Rect(Screen.width - (uiUnit * 2.0f), 0, uiUnit * 2.0f, uiUnit),
		          "HIGH SCORE " + hs.HScore.ToString(), hScoreStyle);
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
