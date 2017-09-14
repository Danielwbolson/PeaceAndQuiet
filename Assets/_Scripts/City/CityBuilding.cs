using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBuilding : MonoBehaviour {
	[HideInInspector]
	public bool isBusy;

	[HideInInspector]
	public bool isEmpty;
	public bool wasBuilt = true;

	public string whatBuildingIsThis;

	public GameObject BuildingMenu;

	// Use this for initialization
	void Start() {
		if (!wasBuilt && whatBuildingIsThis != "Castle") {
			Vector2 location = new Vector2(1f, 1f);
			Collider2D collider = Physics2D.OverlapBox(transform.position, location, 0f, LayerMask.GetMask("EmptyField"), -Mathf.Infinity, Mathf.Infinity);
			if (collider.gameObject != null) {
				transform.SetParent(collider.gameObject.transform);
				transform.parent.GetComponent<emptyField>().isEmpty = false;
			}
		}
		if (whatBuildingIsThis == "Blacksmith")
			Controller.Blacksmith = true;
		else if (whatBuildingIsThis == "Great Hall")
			Controller.GreatHall = true;
		else if (whatBuildingIsThis == "Warehouse")
			Controller.Warehouse = true;
		else if (whatBuildingIsThis == "Tailor")
			Controller.Tailor = true;
		else if (whatBuildingIsThis == "Castle")
			Controller.Castle = true;
		else if (whatBuildingIsThis == "House")
			Debug.Log("House was built");
		else if (whatBuildingIsThis == "Barracks")
			Debug.Log("Barracks built");
			//Troop speed, happiness
	}

	private void OnMouseOver() {
		if (isEmpty) {
			if (Input.GetMouseButtonDown(0) && (GameObject.FindGameObjectWithTag("Menu") == null)) {
				Instantiate(BuildingMenu, Vector3.zero, Quaternion.identity);
				Controller.whatWasClicked = gameObject;
			}
		}
	}
}
