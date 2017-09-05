using UnityEngine;
using System.Collections;

public class emptyField : MonoBehaviour {
	public GameObject MenuPanel;
	public Sprite newSprite;
	
	private Sprite oldSprite;
	
	[HideInInspector]
	public bool
		isEmpty = true;

	void Start() {
		oldSprite = GetComponent<SpriteRenderer>().sprite;
		if(transform.childCount != 0) {
			isEmpty = false;
		}
	}

	void OnMouseOver() {
		//Debug.Log("Over empty field");
		if(GameObject.FindGameObjectWithTag("Menu") == null) {
			if(Input.GetMouseButtonDown(0)) {
				if(isEmpty) {
					//let player build something
					//click to bring up interface to see what can be built
					Instantiate(MenuPanel, Vector3.zero, Quaternion.identity);
					Controller.whatWasClicked = gameObject;
				} else {
					Debug.Log("You cannot build");
				}
			}
		}
	}

	void OnMouseEnter() {
		if(isEmpty && GameObject.FindGameObjectWithTag("Menu") == null) {
			GetComponent<SpriteRenderer>().sprite = newSprite;
		}
	}

	void OnMouseExit() {
		GetComponent<SpriteRenderer>().sprite = oldSprite;
	}
	
	//needs to change mouse position to game positon
	Vector3 MousePosition() {
		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
		Vector3 OnScreenMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		return OnScreenMousePosition;
	}
}
