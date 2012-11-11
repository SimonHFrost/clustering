using UnityEngine;
using System.Collections;

public class DragNDrop : MonoBehaviour {
	
	IEnumerator OnMouseDown()
	{
	    Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);
	    Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
	
	    while (Input.GetMouseButton(0))
	    {
			SetDragged(true);
	        Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
	        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
	        transform.position = curPosition;
	        yield return null;
	    }
	}
	
	public void OnMouseUp() {
		SetDragged(false);
	}
	
	private void SetDragged(bool toggle) {
		gameObject.GetComponent<Behaviour>().beingDragged = toggle;	
	}
}
