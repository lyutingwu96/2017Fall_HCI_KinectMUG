using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUG_Data : MonoBehaviour {

	public static float BPM=0;
	public static float[] arrayOfSecond;
	public static bool[] note1;
	public static bool[] note2;
	public static bool[] note3;
	public static bool[] note4;
	public static bool[] note5;
	public static int len;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void debugPrint(){
		Debug.Log ("BPM:"+BPM);
		/*for (int k = 0; k < len-1; k++) {

		Debug.Log ("time:"+arrayOfSecond[k]+" note:"+note1[k]+" "+note2[k]+" "+note3[k]+" "+note4[k]+" "+note5[k]);
		}*/
	} 
}
