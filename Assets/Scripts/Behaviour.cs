using UnityEngine;
using System.Collections;

public class Behaviour : MonoBehaviour {
	
	private bool uncomfortable;
	
	public void Shuffle() {
		uncomfortable = CheckComfortableness();
		UpdateStatus(uncomfortable);
		
		if(!uncomfortable) {
			return;	
		}
		
		var x = 0;
		var z = 0;
		
		if(Random.value > 0.5) {
			if(Random.value > 0.5) {
				x = 1;	
			} else {
				x = -1;	
			}
		} else {
			if(Random.value > 0.5) {
				z = 1;	
			} else {
				z = -1;	
			}
		}
		
		Vector3 direction = new Vector3(x, 0, z);
		this.transform.Translate(direction);
		
		uncomfortable = false;
	}
	
	bool CheckComfortableness () {
		if(!uncomfortable) {
			GameObject[] others = GameObject.FindGameObjectsWithTag("Toon");
			foreach(GameObject other in others) {
				if(gameObject.transform.collider.bounds.Contains(other.transform.position)
					&& other != gameObject) {
					return true;
				}	
			}
		}
		return false;
	}
	
	private void UpdateStatus(bool uncomfortable) {
		MeshRenderer status = transform.Find("Status").GetComponent<MeshRenderer>();
		status.enabled = uncomfortable;
	}
			
}
