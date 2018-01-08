using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NoteStateManager : MonoBehaviour {
	//public static NoteStateManager Instance;
	public List <circleController> livingNotes;
	public List <int> touched;

	public GameObject p;
	public GameObject g;
	public GameObject m;

	public int index = 0;

	public int ID;

	// Use this for initialization
	void Start () {
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (ID + "   Count: " + livingNotes.Count + "   touched: " + touched.Count + "   index: " + index);
	}

	public int GetNoteState(){
		if ((livingNotes.Count == 0) || (index >= livingNotes.Count)) {
			return 0;
		} else {
			if (livingNotes[index].triggerTimer == 0) {
				return 0;
			} else if ((livingNotes[index].triggerTimer == 1) && (touched[index]!=1)) {
				livingNotes[index].noteDead ();
				printState (1);
				addIndex (index);
				return 1;

			} else if ((livingNotes[index].triggerTimer == 2)&& (touched[index]!=1)) {
				livingNotes[index].noteGood ();
				printState (2);
				addIndex (index);
				return 2;

			} else if ((livingNotes[index].triggerTimer == 3) && (touched[index]!=1)) {
				livingNotes[index].notePerfect ();
				printState (3);
				addIndex (index);
				return 3;

			} else {
				return 0;
			}
		}
	}

	public void printState(int State){
		m.GetComponent<Animator> ().ResetTrigger("miss");
		g.GetComponent<Animator>().ResetTrigger("good");
		p.GetComponent<Animator>().ResetTrigger("perfect");

		if (State == 1) {
			m.GetComponent<Animator> ().SetTrigger("miss");

		} else if (State == 2) {
			g.GetComponent<Animator>().SetTrigger("good");

		} else if (State == 3) {
			p.GetComponent<Animator>().SetTrigger("perfect");

		}
	}

	public void noteAdd(circleController newNote){
		livingNotes.Add (newNote);
	}
	public void touchedAdd(int isTouched){
		touched.Add (isTouched);
		//Debug.Log (ID + "   count touched: " + touched.Count);
	}
		
	public void addIndex(int noteID){
		//Debug.Log ("noteID: " + noteID + "   index: " + index + "   touched: " + touched [noteID]);
		if ((noteID == index) && (touched[noteID] != 1)){
			//Debug.Log ("noteID: " + noteID + "   index: " + index + "   touched: " + touched [noteID]);
			index = index + 1;
			touched [noteID] = 1;
		}
	}
		
}
