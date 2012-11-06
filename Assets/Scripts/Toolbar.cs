using UnityEngine;
using System.Collections;

public class Toolbar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		var width = 100.0f;
		var height = 30.0f;
		
		Rect rect = new Rect((float)(Screen.width * 0.5 - width / 2.0), (float)(Screen.height * 0.1 - height / 2.0), width, height);
		
		string buttonName = GameObject.Find("ClusterController").GetComponent<ClusterController>().Move ? "STOP" : "START";
		
		if(GUI.Button(rect, buttonName)) {
			GameObject.Find("ClusterController").GetComponent<ClusterController>().ToggleMovement();
		}
	}
}
