using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	public Transform toon;
	
	public void MakeToon() {
		Transform instantiatedToon = (Transform)Instantiate(toon, new Vector3(0,0,0), Quaternion.identity);
		instantiatedToon.name = "Toon";
		instantiatedToon.transform.parent = GameObject.Find("Master").transform;
	}
	
}
