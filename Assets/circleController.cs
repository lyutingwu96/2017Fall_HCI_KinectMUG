using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class circleController : MonoBehaviour {

	float x = 0;
	float y = 0;
	public GameObject target;
	float targetX;
	float targetY;
	public GameObject circle;

	// Use this for initialization
	void Start () {
		x = 0.0f;
		y = 0.0f;
		targetX = target.transform.localPosition.x;
		targetY = target.transform.localPosition.y;
		//Debug.Log ("targetX:" + targetX + "   targetY:" + targetY);
//		circle.GetComponent<Animator> ().speed = 1.0f * MUG_Data.BPM;
	}
	
	// Update is called once per frame
	/*void Update () {
		x = this.transform.localPosition.x;
		y = this.transform.localPosition.y;
		float deltaX = x - targetX;
		float deltaY = y - targetY;
		float deltaP = deltaX * deltaX + deltaY * deltaY;



		if (deltaP < 20.0f) {
			Debug.Log ("X:" + x + "  Y:" + y + "   deltaX:" + deltaX + "   deltaY:" + deltaY + "   deltaP:" + deltaP);
			GameObject newCircle = Instantiate (circle, circle.transform.position, circle.transform.rotation);
			newCircle.transform.SetParent (GameObject.FindGameObjectWithTag ("NoteCanvas").transform, false);
			newCircle.GetComponent<Animator> ().speed = 0.5f * MUG_Data.BPM;
		}

	}*/

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Trigger!!");
		GameObject newCircle = Instantiate (circle, circle.transform.position, circle.transform.rotation);
		newCircle.transform.SetParent (GameObject.FindGameObjectWithTag ("NoteCanvas").transform, false);
		newCircle.GetComponent<Animator> ().speed = 0.5f * MUG_Data.BPM;
		this.GetComponent<CircleCollider2D> ().enabled = false;
	}
}
