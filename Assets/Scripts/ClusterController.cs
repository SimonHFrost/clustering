using UnityEngine;
using System.Collections;
using System.Linq;

public class ClusterController : MonoBehaviour {
	
	public bool Move = false;
	private GameObject[] _toons;
	private float timer;
	
	void Start() {
		FindToons();
	}
	
	void Update() {
		if(Move) {
			timer += Time.deltaTime;
			if(timer > 0.1) {
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
	
	public void Reset() {
		Move = false;
		foreach(GameObject toon in _toons) {
			toon.transform.position = new Vector3(0f,0f,0f);	
		}
	}
	
	public int GetTotalNumberOfToons() {
		return _toons.Length;
	}
	
	public int GetHappyNumberOfToons() {
		int sum = 0;
		foreach(GameObject toon in _toons) {
			if(!toon.GetComponent<Behaviour>().uncomfortable) {
				sum += 1;
			}
		}
		return sum;
	}
}
