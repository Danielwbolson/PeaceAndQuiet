using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBuilding : MonoBehaviour {
	[HideInInspector]
	public bool isBusy;

	[HideInInspector]
	public bool isEmpty;


	public GameObject BuildingMenu;
	public string building;

	// Use this for initialization
	void Start() {
		if (building == "Blacksmith")
			Controller.Blacksmith = true;
		else if (building == "GreatHall")
			Controller.GreatHall = true;
		else if (building == "Warehouse")
			Controller.Warehouse = true;
		else if (building == "Tailor")
			Controller.Tailor = true;
		else if (building == "Castle")
			Controller.Castle = true;
		else if (building == "House")
			Controller.Population += 6;
		else if (building == "Barracks")
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
