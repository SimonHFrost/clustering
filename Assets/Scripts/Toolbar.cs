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
		
		SequenceController clusterController = GameObject.Find("MainController").GetComponent<SequenceController>();
		
		int totalNumberOfToons = clusterController.GetTotalNumberOfToons();
		
		GUI.Label(statusRect, totalNumberOfToons + " TOONS");
	}
	
	void MakeAddButton() {
		float x = (float)(Screen.width * 0.75 - width / 2.0);
		float y = (float)(Screen.height * 0.1 - height / 2.0);
		Rect addRect = new Rect(x, y, width, height);
		
		SequenceController clusterController = GameObject.Find("MainController").GetComponent<SequenceController>();
		
		if(GUI.Button(addRect, "CLICK ME")) {
			clusterController.GetComponent<SceneController>().MakeToon();
		}
	}
}
