using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNotes : MonoBehaviour {

//	public MUG_Data MusicData;

	public GameObject PreOne;
	public GameObject PreTwo;
	public GameObject PreThree;
	public GameObject PreFour;
	public GameObject PreFive;

	public NoteStateManager FixedOne;
	public NoteStateManager FixedTwo;
	public NoteStateManager FixedThree;
	public NoteStateManager FixedFour;
	public NoteStateManager FixedFive;

//	int len = MUG_Data.len;
	int k = 1;
	float Spb;
	float fourSpb;
	public float adjustTime = 0.0f;


	public AudioSource audioSource;
	// Use this for initialization

	void Awake(){
		Application.targetFrameRate = 200;
		Spb = 60.0f / MUG_Data.BPM;
		fourSpb = Spb * 4;
	}

	void Start () {
		//Debug.Log(fourSpb);
	}
	
	// Update is called once per frame
	void Update () {

		float temp = audioSource.time + adjustTime + fourSpb - MUG_Data.arrayOfSecond [k];
		//Debug.Log ("temp:" + temp);
		//Debug.Log ("Source:" + audioSource.time + "   MUG_Data:" + MUG_Data.arrayOfSecond [k] + "   Minus:" + temp);
		if ((temp < 0.1) && (temp > 0)) {
			//Debug.Log ("Source:" + audioSource.time + "   MUG_Data:" + MUG_Data.arrayOfSecond [k] + "   Minus:" + temp);
			//Debug.Log ("noteNUM: " + k);
			if (MUG_Data.note1[k]) {
				GameObject One = Instantiate (PreOne, PreOne.transform.position, PreOne.transform.rotation);
				One.transform.SetParent (GameObject.FindGameObjectWithTag ("NoteCanvas").transform, false);
				One.GetComponent<Animator> ().speed = 0.25f * MUG_Data.BPM;
				FixedOne.noteAdd (One.GetComponent<circleController>());
				FixedOne.touchedAdd (0);
				One.GetComponent<circleController> ().SetNoteID (FixedOne.livingNotes.Count);
				//Debug.Log ("one IINNN: " + FixedOne.livingNotes.Count);
				//FixedOne.noteOBJEnqueue (One);

			} 
			if (MUG_Data.note2[k]) {
				GameObject Two = Instantiate (PreTwo, PreTwo.transform.position, PreTwo.transform.rotation);
				Two.transform.SetParent (GameObject.FindGameObjectWithTag ("NoteCanvas").transform, false);
				Two.GetComponent<Animator> ().speed = 0.25f * MUG_Data.BPM;
				FixedTwo.noteAdd (Two.GetComponent<circleController>());
				FixedTwo.touchedAdd (0);
				Two.GetComponent<circleController> ().SetNoteID (FixedTwo.livingNotes.Count);
				//FixedTwo.noteOBJEnqueue (Two);

			}
			if (MUG_Data.note3[k]) {
				GameObject Three = Instantiate (PreThree, PreThree.transform.position, PreThree.transform.rotation);
				Three.transform.SetParent (GameObject.FindGameObjectWithTag("NoteCanvas").transform, false);
				Three.GetComponent<Animator>().speed = 0.25f * MUG_Data.BPM;
				FixedThree.noteAdd (Three.GetComponent<circleController>());
				FixedThree.touchedAdd (0);
				Three.GetComponent<circleController> ().SetNoteID (FixedThree.livingNotes.Count);
				//FixedThree.noteOBJEnqueue (Three);

			}
			if (MUG_Data.note4[k]) {
				GameObject Four = Instantiate (PreFour, PreFour.transform.position, PreFour.transform.rotation);
				Four.transform.SetParent (GameObject.FindGameObjectWithTag("NoteCanvas").transform, false);
				Four.GetComponent<Animator>().speed = 0.25f * MUG_Data.BPM;
				FixedFour.noteAdd (Four.GetComponent<circleController>());
				FixedFour.touchedAdd (0);
				Four.GetComponent<circleController> ().SetNoteID (FixedFour.livingNotes.Count);
				//FixedFour.noteOBJEnqueue (Four);

			}
			if (MUG_Data.note5[k]) {
				GameObject Five = Instantiate (PreFive, PreFive.transform.position, PreFive.transform.rotation);
				Five.transform.SetParent (GameObject.FindGameObjectWithTag("NoteCanvas").transform, false);
				Five.GetComponent<Animator>().speed = 0.25f * MUG_Data.BPM;
				FixedFive.noteAdd (Five.GetComponent<circleController>());
				FixedFive.touchedAdd (0);
				Five.GetComponent<circleController> ().SetNoteID (FixedFive.livingNotes.Count);
				//FixedFive.noteOBJEnqueue (Five);
			}

			if (k < MUG_Data.len - 1) {
				k = k + 1;
			}
		}
	}
}
