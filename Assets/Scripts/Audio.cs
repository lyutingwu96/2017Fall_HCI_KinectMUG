using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour {
	public List<AudioClip> clips;
	private int soundtrack;
	private bool[] Gesture = new bool[4];
	private string[] songName=new string[4];
	private AudioSource aud;
	private bool pauseOrNot;
	private bool isPlaying = true;
	public List<TextAsset> TxtFile;


	private string Mytxt;    //用来存放文本内容

	int len=0;
	float BPM=0;
	int perfectScore;
	float[] arrayOfSecond;
	bool[] note1;
	bool[] note2;
	bool[] note3;
	bool[] note4;
	bool[] note5;
	//public MUG_Data fun;
	public GameObject menu;
	public GameObject canvas1;
	public GameObject canvas2;
	public GameObject game;
	bool isShowing=true;
	bool isShowing1=false;
	bool isShowing2=false;
	public PlayingManager PM;
	[SerializeField]private Text songText;
	public Animator p1;
	public Animator g1;
	public Animator m1;
	public Animator p2;
	public Animator g2;
	public Animator m2;
	public Animator p3;
	public Animator g3;
	public Animator m3;
	public Animator p4;
	public Animator g4;
	public Animator m4;
	public Animator p5;
	public Animator g5;
	public Animator m5;

	[SerializeField]private Text MovementText=null;
	[SerializeField]private Text nowSongName=null;
	[SerializeField]private Text nowSongNameGame=null;


	// Use this for initialization
	public void ReadTxt () {
		Mytxt = TxtFile[soundtrack].text;
		len = 0;
		string[] splitString = Mytxt.Split('\n');
		foreach (string i in splitString) {
			//print(i);
			len++;
			if (len == 1) {
				BPM = float.Parse (i);
			}
			if (len == 2) {
				perfectScore = int.Parse (i);
			}
		}
		//print (len);

		arrayOfSecond=new float[len];
		note1=new bool[len-2];
		note2=new bool[len-2];
		note3=new bool[len-2];
		note4=new bool[len-2];
		note5=new bool[len-2];


		for (int k = 2; k < len; k++) {
			string[] j = splitString [k].Split(',');
			//foreach (string i in j) {
			//print (i);
			//}
			arrayOfSecond[k-2]=float.Parse (j[0]);
			note1 [k-2] = j [1] == "1" ? true : false;
			note2 [k-2] = j [2] == "1" ? true : false;
			note3 [k-2] = j [3] == "1" ? true : false;
			note4 [k-2] = j [4] == "1" ? true : false;
			note5 [k-2] = j [5] == "1" ? true : false;

		}
		MUG_Data.len = len;
		MUG_Data.BPM = BPM;
		MUG_Data.perfectScore = perfectScore;
		MUG_Data.arrayOfSecond = arrayOfSecond;
		MUG_Data.note1 = note1;
		MUG_Data.note2 = note2;
		MUG_Data.note3 = note3;
		MUG_Data.note4 = note4;
		MUG_Data.note5 = note5;
		//fun.debugPrint (songName[soundtrack]);

		PM.setScore (perfectScore);

		p1.speed = 1.0f * MUG_Data.BPM;
		g1.speed = 1.0f * MUG_Data.BPM;
		m1.speed = 1.0f * MUG_Data.BPM;
		p2.speed = 1.0f * MUG_Data.BPM;
		g2.speed = 1.0f * MUG_Data.BPM;
		m2.speed = 1.0f * MUG_Data.BPM;
		p3.speed = 1.0f * MUG_Data.BPM;
		g3.speed = 1.0f * MUG_Data.BPM;
		m3.speed = 1.0f * MUG_Data.BPM;
		p4.speed = 1.0f * MUG_Data.BPM;
		g4.speed = 1.0f * MUG_Data.BPM;
		m4.speed = 1.0f * MUG_Data.BPM;
		p5.speed = 1.0f * MUG_Data.BPM;
		g5.speed = 1.0f * MUG_Data.BPM;
		m5.speed = 1.0f * MUG_Data.BPM;
		//Debug.Log ("BPM:"+BPM);
		//for (int k = 0; k < len-1; k++) {

		//Debug.Log ("time:"+arrayOfSecond[k]+" note:"+note1[k]+" "+note2[k]+" "+note3[k]+" "+note4[k]+" "+note5[k]);
		//}

	}


	// Use this for initialization
	void Start () {
		soundtrack = 0;

		songName [0] = "gloryday";
		songName [1] = "PONPONPON";
		songName [2] = "SecondHeaven";
		songName [3] = "Summer";
		nowSongName.text= songName [soundtrack];
		nowSongNameGame.text = songName[soundtrack];
		songText.text = songName [soundtrack];

		ReadTxt ();

		pauseOrNot = false;
		aud = GetComponent<AudioSource>();
		aud.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		Gesture = GetComponent<SimpleGestureListener> ().Gesture;

		if (Gesture [0]) {
			MovementText.text = "Swipe Up";
	
			Debug.Log ("0");
			GetComponent<SimpleGestureListener> ().Gesture [0] = false;

			if (isShowing == true) {
				aud.Stop ();
				isShowing = !isShowing;
				menu.SetActive (isShowing);

			} 
			else {
				isShowing = !isShowing;
				menu.SetActive (isShowing);
				play (soundtrack);

			}


		}

		if (Gesture [2]) {
			MovementText.text = "Swipe Left";
			if (!isPlaying) {

				isPlaying = true;
			}
			Debug.Log ("2");
			GetComponent<SimpleGestureListener> ().Gesture [2] = false;
			aud.Stop ();
			soundtrack =(soundtrack+3)%4;
			nowSongName.text = songName [soundtrack];
			nowSongNameGame.text = songName [soundtrack];
			play (soundtrack);
			ReadTxt ();
		}
		if (Gesture [3]) {
			MovementText.text = "Swipe Right";
			if (!isPlaying) {

				isPlaying = true;
			}
			Debug.Log ("3");
			GetComponent<SimpleGestureListener> ().Gesture [3] = false;
			aud.Stop ();
			soundtrack =(soundtrack+1)%4;
			nowSongName.text = songName [soundtrack];
			nowSongNameGame.text = songName [soundtrack];
			play (soundtrack);
			ReadTxt ();
		}
		if (Input.GetMouseButtonDown(0)) {
			aud.Stop ();
			soundtrack =(soundtrack+1)%4;
			nowSongName.text = songName [soundtrack];
			nowSongNameGame.text = songName [soundtrack];
			play (soundtrack);
			ReadTxt ();
			
		}
		if (Input.GetMouseButtonDown (1)) {
			Debug.Log ("GetMouseButtonDown!!!!!");
			
			if (isShowing == true) {
				aud.Stop ();
				isShowing = !isShowing;
				menu.SetActive (false);
				canvas1.SetActive (true);
				canvas2.SetActive (true);
				play (soundtrack);
				game.SetActive (true);


			}
			else {
				isShowing = !isShowing;
				menu.SetActive (true);			}
		}
	}
	void play(int num){
		
		aud.PlayOneShot(clips[num]);
	}


}
