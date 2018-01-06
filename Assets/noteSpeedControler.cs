using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteSpeedControler : MonoBehaviour {

	public Animation AnimOne;
	public Animation AnimTwo;
	public Animation AnimThree;
	public Animation AnimFour;
	public Animation AnimFive;

	float bpm = MUG_Data.BPM;

	void Start()
	{
		// Walk backwards
		AnimOne["1"].speed = 1.0f * bpm;
		AnimTwo["2"].speed = 1.0f * bpm;
		AnimThree["3"].speed = 1.0f * bpm;
		AnimFour["4"].speed = 1.0f * bpm;
		AnimFive["5"].speed = 1.0f * bpm;

	}
}
