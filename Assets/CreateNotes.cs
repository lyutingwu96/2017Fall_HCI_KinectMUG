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
//	int len = MUG_Data.len;
	int k = 1;
	float quaterBpm = MUG_Data.BPM * 0.25f;
	public float adjustTime = 0.25f;

	/*
	private float m_LastUpdateShowTime=0f;    //上一次更新帧率的时间;

	private float m_UpdateShowDeltaTime=0.01f;//更新帧率的时间间隔;

	private int m_FrameUpdate=0;//帧数;

	private float m_FPS=0;
    */

	public AudioSource audioSource;
	// Use this for initialization

	void Awake(){
		Application.targetFrameRate = 200;
	}

	void Start () {
		//m_LastUpdateShowTime=Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		m_FrameUpdate++;
		if(Time.realtimeSinceStartup-m_LastUpdateShowTime>=m_UpdateShowDeltaTime)
		{
			m_FPS=m_FrameUpdate/(Time.realtimeSinceStartup-m_LastUpdateShowTime);
			m_FrameUpdate=0;
			m_LastUpdateShowTime=Time.realtimeSinceStartup;
		}
		Debug.Log ("FPS: " + m_FPS);*/

		float temp = audioSource.time - quaterBpm - MUG_Data.arrayOfSecond [k];
		//Debug.Log ("Source:" + audioSource.time + "   MUG_Data:" + MUG_Data.arrayOfSecond [k] + "   Minus:" + temp);
		if ((audioSource.time - adjustTime - quaterBpm - MUG_Data.arrayOfSecond [k] < 0.1) && (audioSource.time - MUG_Data.arrayOfSecond [k] > 0)) {
			if (MUG_Data.note1[k]) {
				GameObject One = Instantiate (PreOne, PreOne.transform.position, PreOne.transform.rotation);
				One.transform.SetParent (GameObject.FindGameObjectWithTag ("NoteCanvas").transform, false);
				One.GetComponent<Animator> ().speed = 0.25f * MUG_Data.BPM;

			} 
			if (MUG_Data.note2[k]) {
				GameObject Two = Instantiate (PreTwo, PreTwo.transform.position, PreTwo.transform.rotation);
				Two.transform.SetParent (GameObject.FindGameObjectWithTag ("NoteCanvas").transform, false);
				Two.GetComponent<Animator> ().speed = 0.25f * MUG_Data.BPM;

			}
			if (MUG_Data.note3[k]) {
				GameObject Three = Instantiate (PreThree, PreThree.transform.position, PreThree.transform.rotation);
				Three.transform.SetParent (GameObject.FindGameObjectWithTag("NoteCanvas").transform, false);
				Three.GetComponent<Animator>().speed = 0.25f * MUG_Data.BPM;

			}
			if (MUG_Data.note4[k]) {
				GameObject Four = Instantiate (PreFour, PreFour.transform.position, PreFour.transform.rotation);
				Four.transform.SetParent (GameObject.FindGameObjectWithTag("NoteCanvas").transform, false);
				Four.GetComponent<Animator>().speed = 0.25f * MUG_Data.BPM;

			}
			if (MUG_Data.note5[k]) {
				GameObject Five = Instantiate (PreFive, PreFive.transform.position, PreFive.transform.rotation);
				Five.transform.SetParent (GameObject.FindGameObjectWithTag("NoteCanvas").transform, false);
				Five.GetComponent<Animator>().speed = 0.25f * MUG_Data.BPM;
			}

			if (k < MUG_Data.len - 1) {
				k = k + 1;
			}
		}
	}
}
