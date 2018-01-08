using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class circleController : MonoBehaviour {

	int noteID;


	public GameObject circle;
	public int triggerTimer = 0;
	public int triggerTimerExit = 0;

	public Sprite DeadNote;
	public Sprite GoodNote;
	public Sprite PerfectNote;
	public string NSTid;
	NoteStateManager NST;

	void Start () {
		NST = GameObject.Find (NSTid).GetComponent<NoteStateManager>();
		//Debug.Log (NST.ID + "   noteID: " + noteID);
	}


	void OnTriggerEnter2D(Collider2D other){
		if (triggerTimer == 0) {
			//Debug.Log ("Miss!!");
			triggerTimer = triggerTimer + 1;

		}else if (triggerTimer == 1) {
			//Debug.Log ("Good!!");
			triggerTimer = triggerTimer + 1;
		
		} else if (triggerTimer == 2) {
			//Debug.Log ("Perfect!!");
			triggerTimer = triggerTimer + 1;

			GameObject newCircle = Instantiate (circle, circle.transform.position, circle.transform.rotation);
			newCircle.transform.SetParent (GameObject.FindGameObjectWithTag ("NoteCanvas").transform, false);
			newCircle.GetComponent<Animator> ().speed = 0.5f * MUG_Data.BPM;

		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (triggerTimerExit == 0) {
			triggerTimerExit = triggerTimerExit + 1;
			//leave miss collider

		} else if (triggerTimerExit == 1) {
			triggerTimerExit = triggerTimerExit + 1;
			triggerTimer = 2;
			//leave perfect collider == GOOD

		} else if (triggerTimerExit == 2) {
			triggerTimer = 1;
			noteDead ();
			this.GetComponent<Collider2D> ().enabled = false;
			//leave good collider == MISS
			//Debug.Log (NST.ID + "   noteID: " + noteID + "   Miss!!");
			//NST.addIndex (noteID);
			NST.addIndex(noteID);
		}
	}

	public void noteDead(){
		this.GetComponent<Image> ().sprite = DeadNote;
	}
	public void noteGood(){
		this.GetComponent<Image> ().sprite = GoodNote;
	}
	public void notePerfect(){
		this.GetComponent<Image> ().sprite = PerfectNote;
	}

	public void SetNoteID(int currentCount){
		noteID =(int) currentCount - 1;
	}

}
