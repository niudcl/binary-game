/***************************************
 * 
 * 	DoorManager
 * 
 * 	Creates doors. Holds global "speed".
 * 
 * ************************************/
using UnityEngine;
using System.Collections.Generic;

public class DoorManager : MonoBehaviour {

	private int doorCount = 5;		
	private int doorSpacing = 24;
	private List<DynamicDoor> doors;
	private float speed = -3.0f;
	private List<GameObject> speedListeners;

	public DynamicDoor door;
	public float Speed {
		get { return speed; }
		set { 
			speed = value; 
			BroadcastSpeed();
		}
	}

	private void Awake () {
		doors = new List<DynamicDoor>();
		speedListeners = new List<GameObject>();
		BuildDoors();
	}

	private void Start () {
		AddSpeedListeners();
	}

	private void BuildDoors () {
		for(int i = 0; i < doorCount; i++) {
			DynamicDoor d = (DynamicDoor)Instantiate(door, 
			                           new Vector3(doorSpacing * i + doorSpacing * 1.5f, 0, 0),
			                           Quaternion.identity);
			d.Speed = speed;
			d.DoorCount = doorCount;
			d.DoorSpacing = doorSpacing;
			doors.Add(d);
		}
	}

	private void BroadcastSpeed () {
		foreach(GameObject s in speedListeners) {
			s.SendMessage("UpdateSpeed", speed);
		}
	}

	private void AddSpeedListeners () {
		foreach(DynamicDoor door in doors) {
			speedListeners.Add(door.gameObject);
		}
		GroundMover[] gm = FindObjectsOfType<GroundMover>();
		foreach(GroundMover ground in gm) {
			speedListeners.Add(ground.gameObject);
		}
	}
}
