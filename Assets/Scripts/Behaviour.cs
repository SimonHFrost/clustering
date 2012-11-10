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
		
		Vector2 direction = DetermineDirection();
		Vector3 newPosition = new Vector3(direction.x, 0, direction.y);
		
		this.transform.Translate(newPosition);
		
		uncomfortable = false;
	}
	
	private bool CheckComfortableness () {
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
	
	private Vector2 DetermineDirection() {
		float xsum = 0;
		float zsum = 0;
		
		GameObject[] toons = GameObject.FindGameObjectsWithTag("Toon");
		foreach(GameObject toon in toons) {
			xsum += toon.transform.position.x;
			zsum += toon.transform.position.z;
		}
		
		float averageX = (float)xsum / (float)toons.Length;
		float averageZ = (float)zsum / (float)toons.Length;
		
		Vector2 currentPos = new Vector2(transform.position.x, transform.position.z);
		Vector2 averagePos = new Vector2(averageX, averageZ);
		
		Vector2 newPos = currentPos - averagePos;
		newPos.Normalize();
		Vector2 touchOfRandom = Random.insideUnitCircle;
		touchOfRandom.Scale(new Vector2(5f, 5f));
		newPos = newPos + touchOfRandom;
		
		Debug.Log(newPos);
		
		newPos.Scale(new Vector2(0.1f, 0.1f));
		return newPos;
	}
}
