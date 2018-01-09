using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandKeyboardController : MonoBehaviour {
	public GameObject leftHand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 x=new Vector3(0.1f,0,0);
		Vector3 y = new Vector3 (0, 0.1f, 0);
		if (Input.GetKey (KeyCode.S)) {
			leftHand.transform.position += y;
		}
		if (Input.GetKey (KeyCode.X)) {
			leftHand.transform.position -= y;
		}
		if (Input.GetKey (KeyCode.Z)) {
			leftHand.transform.position -= x;
		}
		if (Input.GetKey (KeyCode.C)) {
			leftHand.transform.position += x;
		}
	}
}
