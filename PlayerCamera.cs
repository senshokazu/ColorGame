using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
	public GameObject player;
	Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 newposition = transform.position;
		newposition.x = player.transform.position.x +  offset.x;
		newposition.y = 3.0f;
		newposition.z = player.transform.position.z + offset.z;
		transform.position = Vector3.Lerp(transform.position,newposition,3.0f*Time.deltaTime);
	}
}
