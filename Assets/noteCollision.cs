using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteCollision : MonoBehaviour {
	public NoteStateManager FixedOne;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Collision");
		Debug.Log(FixedOne.GetNoteState ());

	}

	// Update is called once per frame
	void Update () {
		
	}
}
