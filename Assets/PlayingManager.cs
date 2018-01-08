using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayingManager : MonoBehaviour {
	public NoteStateManager FixedOne;
	public NoteStateManager FixedTwo;
	public NoteStateManager FixedThree;
	public NoteStateManager FixedFour;
	public NoteStateManager FixedFive;

	[SerializeField] private Text ScoreText;
	public int GoodScore;
	public int PerfectScore;
	int scoreState;
	int score = 0;

	// Use this for initialization
	void Start () {
		ScoreText.text = "0";
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			scoreState = FixedOne.GetNoteState ();

		}else if(Input.GetKeyDown (KeyCode.W)){
			scoreState = FixedTwo.GetNoteState ();

		}else if(Input.GetKeyDown (KeyCode.E)){
			scoreState = FixedThree.GetNoteState ();

		}else if(Input.GetKeyDown (KeyCode.R)){
			scoreState = FixedFour.GetNoteState ();

		}else if(Input.GetKeyDown (KeyCode.T)){
			scoreState = FixedFive.GetNoteState ();
		}

		if (scoreState == 2) {
			score = score + GoodScore;
		} else if (scoreState == 3) {
			score = score + PerfectScore;
		}
		ScoreText.text = score.ToString();
		scoreState = 0;
	}
}
