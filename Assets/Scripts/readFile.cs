using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class readFile : MonoBehaviour {

	public TextAsset TxtFile;   //建立TextAsset
	private string Mytxt;    //用来存放文本内容
	int len=0;
	string songName; //111
	float BPM=0;
	float[] arrayOfSecond;
	bool[] note1;
	bool[] note2;
	bool[] note3;
	bool[] note4;
	bool[] note5;
	public MUG_Data fun;

	//111
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


	[SerializeField]private Text songText;
	// Use this for initialization
	public void ReadTxt () {
		Mytxt = TxtFile.text;
		string[] splitString = Mytxt.Split('\n');
		foreach (string i in splitString) {
			//print(i);
			len++;
			if (len == 1) {
				BPM = float.Parse (i);
			}
			if (len == 2) {
				songName = i;
				songText.text = i;
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
		MUG_Data.arrayOfSecond = arrayOfSecond;
		MUG_Data.note1 = note1;
		MUG_Data.note2 = note2;
		MUG_Data.note3 = note3;
		MUG_Data.note4 = note4;
		MUG_Data.note5 = note5;
		//fun.debugPrint ();



		//111
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

	void Start(){
		
	}
	// Update is called once per frame
	void Update () {
	}

}
