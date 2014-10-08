using UnityEngine;
using System.Collections;

public class PlayerPart : MonoBehaviour {

	private ParticleEmitter pEmitter;

	public Transform Player;
	public Material ParticleMaterial;

	void Start () {
		pEmitter = GetComponent<ParticleEmitter>();
	}

	void Update () {
		//pEmitter.particles;
	}
}
