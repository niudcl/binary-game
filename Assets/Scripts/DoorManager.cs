using UnityEngine;
using System.Collections.Generic;

public class DoorManager : MonoBehaviour {

	private int doorCount = 10;
	private int doorSpacing = 24;
	private List<DynamicDoor> doors;
	private float speed = -3.0f;

	public DynamicDoor door;
	
	private void Start () {
		doors = new List<DynamicDoor>();
		BuildDoors();
	}

	private void BuildDoors () {
		for(int i = 0; i < doorCount; i++) {
			DynamicDoor d = (DynamicDoor)Instantiate(door, 
			                           new Vector3(doorSpacing * i + doorSpacing, 0, 0),
			                           Quaternion.identity);
			d.Code = (int)Random.Range(0.0f, 639.9f) / 10;
			d.Speed = speed;
			doors.Add(d);
		}
	}

	public float GetSpeed () {
		return speed;
	}
}
