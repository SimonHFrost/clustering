using UnityEngine;
using System.Collections;

public class Behaviour : MonoBehaviour {
	
	public bool uncomfortable;
	public bool beingDragged;
	
	public Material happyMaterial;
	public Material sadMaterial;
	public Material draggedMaterial;
	
	public void Shuffle() {
		
		if (beingDragged) {
			UpdateStatus();
			return;	
		}
		
		uncomfortable = CheckComfortableness();
		UpdateStatus();
		
		if(!uncomfortable) {
			return;	
		}
		
		Vector2 direction = DetermineDirection();
		iTween.MoveBy(gameObject, new Vector3(direction.x, 0, direction.y), 0.1f);
		
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
	
	private void UpdateStatus() {
		Material material;
		if(beingDragged) {
			material = draggedMaterial;	
		} else {
			material = uncomfortable ? sadMaterial : happyMaterial;
		}
		gameObject.GetComponent<MeshRenderer>().material = material;
	}
	
	private Vector2 DetermineDirection() {
		Vector2 currentPos = new Vector2(transform.position.x, transform.position.z);
		Vector2 averagePos = FindAveragePosition();
		
		Vector2 newPos = currentPos - averagePos;
		newPos.Normalize();
		Vector2 touchOfRandom = Random.insideUnitCircle;
		touchOfRandom.Scale(new Vector2(5f, 5f));
		newPos = newPos + touchOfRandom;
		
		newPos.Scale(new Vector2(0.1f, 0.1f));
		
		return newPos;
	}
	
	private Vector2 FindAveragePosition() {
		float xsum = 0;
		float zsum = 0;
		
		GameObject[] toons = GameObject.FindGameObjectsWithTag("Toon");
		foreach(GameObject toon in toons) {
			xsum += toon.transform.position.x;
			zsum += toon.transform.position.z;
		}
		
		float averageX = (float)xsum / (float)toons.Length;
		float averageZ = (float)zsum / (float)toons.Length;
		
		return new Vector2(averageX, averageZ);
	}
}
