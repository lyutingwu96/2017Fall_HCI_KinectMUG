using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour {
	public GameObject Note1;
	public GameObject Note2;
	public GameObject Note3;
	public GameObject Note4;
	public GameObject Note5;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("EVTER");
		Debug.Log (other);
		if (other == Note1) {
			Debug.Log ("AAAA");
		}
			}

	void OnTriggerExit2D(Collider2D other){
		Debug.Log ("Ecit");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
