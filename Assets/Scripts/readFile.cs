using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class readFile : MonoBehaviour {

	public TextAsset TxtFile;   //建立TextAsset
	private string Mytxt;    //用来存放文本内容
	int len=0;
	float BPM=0;
	float[] arrayOfSecond;
	bool[] note1;
	bool[] note2;
	bool[] note3;
	bool[] note4;
	bool[] note5;
	public MUG_Data fun;

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
		}
		//print (len);

		arrayOfSecond=new float[len];
		note1=new bool[len-1];
		note2=new bool[len-1];
		note3=new bool[len-1];
		note4=new bool[len-1];
		note5=new bool[len-1];


		for (int k = 1; k < len; k++) {
			string[] j = splitString [k].Split(',');
			//foreach (string i in j) {
				//print (i);
			//}
			arrayOfSecond[k-1]=float.Parse (j[0]);
			note1 [k-1] = j [1] == "1" ? true : false;
			note2 [k-1] = j [2] == "1" ? true : false;
			note3 [k-1] = j [3] == "1" ? true : false;
			note4 [k-1] = j [4] == "1" ? true : false;
			note5 [k-1] = j [5] == "1" ? true : false;

		}
		MUG_Data.len = len;
		MUG_Data.BPM = BPM;
		MUG_Data.arrayOfSecond = arrayOfSecond;
		MUG_Data.note1 = note1;
		MUG_Data.note2 = note2;
		MUG_Data.note3 = note3;
		MUG_Data.note4 = note4;
		MUG_Data.note5 = note5;
		fun.debugPrint ();


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
