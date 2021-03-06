using UnityEngine;
using System.Collections;
using System.Linq;

public class SequenceController : MonoBehaviour {
	
	public bool Move = false;
	private GameObject[] _toons;
	private float timer;
	
	void Start() {
		FindToons();
	}
	
	void Update() {
		FindToons();
		if(Move) {
			timer += Time.deltaTime;
			if(timer > 1.0f) {
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
}
