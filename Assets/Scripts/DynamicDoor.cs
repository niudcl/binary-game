/***************************************
 * 
 * 	DynamicDoor
 *  
 *  
 *  
 *  Requires: 	InputManager 	(class)
 * 
 * ************************************/
using UnityEngine;
using System.Collections;

public class DynamicDoor : MonoBehaviour {

	private int code;		// the number on this door
	private Color blank = Color.white;		// color for number
	private Color fill = Color.green;		// color for background
	private GameObject[] wallGrid0, wallGrid1;		// array for left and right digit
	private float size = 1.0f;		// size of base quad
	private float speed;		// speed 
	private Vector3 align = new Vector3(0.0f, 2.0f, 3.0f);		// offset for digits
	private Vector3 spacing = Vector3.back;		// size of space column
	private Quaternion baseRot = Quaternion.Euler(0,90,0);		// base rotation
	private int doorCount;		// number of doors
	private int doorSpacing;		// spacing of doors
	private InputManager iManager;		// scene input manager

	public GameObject BaseWall;		// base quad for bulding door
	public GameObject CorrectEffect;		// particles for success
	public GameObject FailEffect;		// particles for fail
	public float Speed {
		set { speed = value; }
	}
	public int DoorCount {
		set { doorCount = value; }
	}
	public int DoorSpacing {
		set { doorSpacing = value; }
	}

	private void Start () {
		// setup quad spacing
		spacing *= size;

		// connect to inputmanager
		iManager = GameObject.FindObjectOfType<InputManager>();


		// create digits (left, space, right)
		wallGrid0 = CreateGrid(BaseWall, transform.position + align);
		CreateLine(BaseWall, transform.position + align + spacing * 3);
		wallGrid1 = CreateGrid(BaseWall, transform.position + align + spacing * 4);

		UpdateDoor ();
	}

	private void Update () {
		transform.Translate(new Vector3(speed * Time.deltaTime, 0.0f, 0.0f));
	}
	
	private void OnTriggerEnter(Collider c) {
		// collision with player
		if (c.tag == "Player") {
			if (code == iManager.Value) {		// correct
				Instantiate(CorrectEffect);
			} else {		// incorrect
				Instantiate(FailEffect);
				Destroy (c.gameObject);
				Invoke("RestartLevel", 2);
			}
			transform.Translate(Vector3.right * doorSpacing * doorCount);
			UpdateDoor();
		}
	}

	// breaks int into two digits
	private int[] ParsePwd (int pwd) {
		int[] pass = new int[2];
		pass[0] = pwd / 10;
		pass[1] = pwd % 10;
		return pass;
	}

	// builds a grid of baseObj
	private GameObject[] CreateGrid (GameObject baseObj, Vector3 offset) {
		GameObject[] grid = new GameObject[15];
		for (int y = 0; y < 5; y++) {
			for (int x = 0; x < 3; x++) {
				grid[y * 3 + x] = (GameObject)Instantiate(baseObj, offset + 
				                                          new Vector3(0.0f, -size * y, -size * x),
				                                          baseRot);
				grid[y * 3 + x].transform.parent = transform;
			}
		}
		return grid;
	}

	// builds a column of baseObj
	private void CreateLine (GameObject baseObj, Vector3 offset) {
		GameObject obj;
		for (int y = 0; y < 5; y++) {
			obj = (GameObject)Instantiate(baseObj, offset + 
			                             new Vector3(0, -size * y, 0.0f),
			                             baseRot);
			obj.transform.parent = transform;
		}
	}

	// changes the color to "draw" a number
	private GameObject[] ColorGrid (GameObject[] grid, int number) {
		// error checking
		if (number > 9 || number < 0) {
			Debug.LogError("Number passed to ColorGrid outside of range.");
			return grid;
		} else if (grid.Length != 15) {
			Debug.LogError("Grid passed to ColorGrid is not the correct length.");
			return grid;
		}

		bool[] pix = new bool[15];
		switch(number) {
		case 0:
			pix = PixelNums.Zero;
			break;
		case 1:
			pix = PixelNums.One;
			break;
		case 2:
			pix = PixelNums.Two;
			break;
		case 3:
			pix = PixelNums.Three;
			break;
		case 4:
			pix = PixelNums.Four;
			break;
		case 5:
			pix = PixelNums.Five;
			break;
		case 6:
			pix = PixelNums.Six;
			break;
		case 7:
			pix = PixelNums.Seven;
			break;
		case 8:
			pix = PixelNums.Eight;
			break;
		case 9:
			pix = PixelNums.Nine;
			break;
		}

		for (int i = 0; i < 15; i++) {
			grid[i].renderer.material.color = (pix[i]) ? fill : blank; 
		}

		return grid;
	}

	private void RestartLevel () {
		Application.LoadLevel(Application.loadedLevel);
	}

	// door generates and shows the code
	public void UpdateDoor () {
		code = (int)Random.Range(0.0f, 639.9f) / 10;
		int[] digits = ParsePwd(code);
		wallGrid0 = ColorGrid (wallGrid0, digits[0]);
		wallGrid1 = ColorGrid (wallGrid1, digits[1]);
	}
}
