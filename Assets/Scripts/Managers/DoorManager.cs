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

	public DynamicDoor door;
	public float Speed {
		get { return speed; }
	}

	private void Start () {
		doors = new List<DynamicDoor>();
		BuildDoors();
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
}
