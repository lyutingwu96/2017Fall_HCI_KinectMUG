using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayingManager : MonoBehaviour {

	[SerializeField] private Text ScoreText;
	public int GoodScore;
	public int PerfectScore;

	int score = 0;

	// Use this for initialization
	void Start () {
		ScoreText.text = "0";
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addScore(int newScore){
		score = score + newScore;
		ScoreText.text = score.ToString();
	}

	public void setScore(int pScore){
		PerfectScore = pScore;
		GoodScore = Mathf.RoundToInt ( pScore * 0.7f);
	}
}
