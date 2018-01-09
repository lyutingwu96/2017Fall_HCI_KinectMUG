using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteCollision : MonoBehaviour {
	public NoteStateManager Fixed;
	public int scoreState = 0;
	public int newScore = 0;
	public PlayingManager pm;
	// Use this for initialization
	void Start () {
		scoreState = 0;
		newScore = 0;
	}
	void OnTriggerEnter2D(Collider2D other){
		scoreState = Fixed.GetNoteState ();
		if (scoreState == 2) {
			newScore = pm.GoodScore;
		} else if (scoreState == 3) {
			newScore = pm.PerfectScore;
		}
		pm.addScore (newScore);
		newScore = 0;
		scoreState = 0;

		Debug.Log ("Collision");
		Debug.Log(Fixed.GetNoteState ());

	}

	// Update is called once per frame
	void Update () {
		
	}
}
