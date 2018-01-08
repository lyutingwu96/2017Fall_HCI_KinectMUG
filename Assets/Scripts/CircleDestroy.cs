using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDestroy : MonoBehaviour {

	float delayTime = 180 / MUG_Data.BPM;

	// Use this for initialization
	void Start () {
		DestroyMySelf ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DestroyMySelf(){
		StartCoroutine(WaitToDestroy());

	}

	IEnumerator WaitToDestroy()
	{
		yield return new WaitForSeconds(delayTime);
		Destroy (this.gameObject);
	}
}
