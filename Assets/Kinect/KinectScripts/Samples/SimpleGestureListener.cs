using UnityEngine;
using System.Collections;
using System;


public class SimpleGestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
	public bool[] Gesture = new bool[4];
	// GUI Text to display the gesture messages.
	public GUIText GestureInfo;
	
	// private bool to track if progress message has been displayed
	private bool progressDisplayed;
	
	
	public void UserDetected(uint userId, int userIndex)
	{
		// as an example - detect these user specific gestures
		KinectManager manager = KinectManager.Instance;

		//manager.DetectGesture(userId, KinectGestures.Gestures.Jump);
		//manager.DetectGesture(userId, KinectGestures.Gestures.Squat);

//		manager.DetectGesture(userId, KinectGestures.Gestures.Push)
	//	manager.DetectGesture(userId, KinectGestures.Gestures.RaiseRightHand);
	//	manager.DetectGesture(userId, KinectGestures.Gestures.RaiseLeftHand);

	//	manager.DetectGesture(userId, KinectWrapper.Gestures.SwipeRight);
	//	manager.DetectGesture(userId, KinectWrapper.Gestures.SwipeLeft);
		
	//	if(GestureInfo != null)
	//	{
	//		GestureInfo.GetComponent<GUIText>().text = "Waiting for User ...";
	//	}
	}
	
	public void UserLost(uint userId, int userIndex)
	{
		if(GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = "User Lost";
		}
	}

	public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              float progress, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		for (int i = 0; i < 4; i++) {
			Gesture [i] = false;
		}
	}

	public bool GestureCompleted (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		//string gestureText = gesture;
		string gestureText = gesture +"";
		if (GestureInfo != null) {
			GestureInfo.GetComponent<GUIText> ().text = gestureText;
			Debug.Log (gestureText);
			if (gestureText== "SwipeUp"){
				Gesture [0] = true;}
			else if (gestureText == "RaiseRightHand"){
				Gesture [1] = false;}
			else if (gestureText == "SwipeLeft"){
				Gesture [2] = true;}
			else if (gestureText == "SwipeRight"){
				Gesture [3] = true;}

		}
		
		progressDisplayed = false;	
		
		return true;
	}

	public bool GestureCancelled (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint)
	{
		if(progressDisplayed)
		{
			// clear the progress info
			if(GestureInfo != null)
				GestureInfo.GetComponent<GUIText>().text = String.Empty;
			
			progressDisplayed = false;
		}
		
		return true;
	}
	
}
