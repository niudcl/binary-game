/***************************************
 * 
 * 	PlayerManager
 * 
 * 	Controls the creation and updating
 * 	of the player's score.
 * 	
 * 	Requires: 	InputManager 	(class)
 * 				Player 			(tag)
 * 
 * ************************************/
using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private TextMesh tm;		// text mesh displayed over the player
	private Vector3 tmOffset = new Vector3(-0.5f, 0.0f, 0.0f);		// text offset from player
	private InputManager iManager;		// scene input manager
	private GameObject player;		// player in scene

	public TextMesh TmPrefab;		// text mesh prefab

	private void Awake () {
		// create player's text mesh for displaying num
		tm = (TextMesh)Instantiate(TmPrefab, 
		                           transform.position + tmOffset, 
		                           Quaternion.identity);
	}

	private void Start () {
		// connect to input manager for setting num
		iManager = GameObject.FindObjectOfType<InputManager>();
		tm.text = iManager.Value.ToString();
		// find player
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	
	private void Update () {
		// follow the player
		tm.transform.position = player.transform.position + Vector3.up;
		// update the text
		tm.text = iManager.Value.ToString();
	}

}
