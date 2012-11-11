using UnityEngine;
using System.Collections;

public class Toolbar : MonoBehaviour {
	
	private float width = 100f;
	private float height = 30f;
	
	void OnGUI() {
		MakeStartButton();
		MakeResetButton();
	}
	
	void MakeStartButton() {
		float x = (float)(Screen.width * 0.5 - width / 2.0);
		float y = (float)(Screen.height * 0.1 - height / 2.0);
		Rect startRect = new Rect(x, y, width, height);
		
		string buttonName = GameObject.Find("ClusterController").GetComponent<ClusterController>().Move ? "STOP" : "START";
		
		if(GUI.Button(startRect, buttonName)) {
			GameObject.Find("ClusterController").GetComponent<ClusterController>().ToggleMovement();
		}
	}
	
	void MakeResetButton() {
		float x = (float)(Screen.width * 0.5 - width / 2.0);
		float y = (float)(Screen.height * 0.2 - height / 2.0);
		Rect resetRect = new Rect(x, y, width, height);
		
		if(GUI.Button(resetRect, "RESET")) {
			GameObject.Find("ClusterController").GetComponent<ClusterController>().Reset();	
		}
	}
}
