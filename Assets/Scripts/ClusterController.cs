using UnityEngine;
using System.Collections;

public class ClusterController : MonoBehaviour {
	
	public bool Move = true;
	private GameObject[] _toons;
	public enum mood { Unsettled, Fine }
	private float timer;
	
	void Start() {
		FindToons();
	}
	
	void Update() {
		if(Move) {
			timer += Time.deltaTime;
			if(timer >= 0.5) {
				AdjustCluster();
				timer = 0;
			}
		}	
	}
	
	void FindToons() {
		_toons = GameObject.FindGameObjectsWithTag("Toon");
	}
	
	public void AdjustCluster() {

		foreach(GameObject toon in _toons) {
			toon.GetComponent<Behaviour>().Shuffle();	
		}
	}
	
	public void ToggleMovement() {
		Move = !Move;
	}
}
