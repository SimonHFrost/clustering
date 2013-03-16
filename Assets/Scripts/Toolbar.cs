using UnityEngine;
using System.Collections;

public class Toolbar : MonoBehaviour {
	
	private float width = 100f;
	private float height = 30f;
	
	void OnGUI() {
		MakeStartButton();
		MakeResetButton();
		MakeStatusLabel();
		MakeAddButton();
		DetectScrollWheel();
	}
	
	void MakeStartButton() {
		float x = (float)(Screen.width * 0.5 - width / 2.0);
		float y = (float)(Screen.height * 0.1 - height / 2.0);
		Rect startRect = new Rect(x, y, width, height);
		
		string buttonName = GameObject.Find("MainController").GetComponent<SequenceController>().Move ? "STOP" : "START";
		
		if(GUI.Button(startRect, buttonName)) {
			GameObject.Find("MainController").GetComponent<SequenceController>().ToggleMovement();
		}
	}
	
	void MakeResetButton() {
		float x = (float)(Screen.width * 0.5 - width / 2.0);
		float y = (float)(Screen.height * 0.2 - height / 2.0);
		Rect resetRect = new Rect(x, y, width, height);
		
		if(GUI.Button(resetRect, "RESET")) {
			GameObject.Find("MainController").GetComponent<SequenceController>().Reset();	
		}
	}
	
	void MakeStatusLabel() {
		float x = (float)(Screen.width * 0.75 - width / 2.0);
		float y = (float)(Screen.height * 0.2 - height / 2.0);
		Rect statusRect = new Rect(x, y, width, height);
		
		SequenceController sequenceController = GameObject.Find("MainController").GetComponent<SequenceController>();
		
		int totalNumberOfToons = sequenceController.GetTotalNumberOfToons();
		
		GUI.Label(statusRect, totalNumberOfToons + " TOONS");
	}
	
	void MakeAddButton() {
		float x = (float)(Screen.width * 0.75 - width / 2.0);
		float y = (float)(Screen.height * 0.1 - height / 2.0);
		Rect addRect = new Rect(x, y, width, height);
		
		SequenceController clusterController = GameObject.Find("MainController").GetComponent<SequenceController>();
		
		if(GUI.RepeatButton(addRect, "CLICK ME")) {
			clusterController.GetComponent<SceneController>().MakeToon();
		}
	}
	
	void DetectScrollWheel() {
		float change = Input.GetAxis("Mouse ScrollWheel") * 5.0f;	
		if(change != 0) {
			GameObject.Find("Main Camera").transform.Translate(new Vector3(0.0f, 0.0f, change));
		}
	}
}
