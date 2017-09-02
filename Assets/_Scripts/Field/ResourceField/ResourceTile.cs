using UnityEngine;
using System.Collections;

public class ResourceTile : MonoBehaviour {

	public string whatBuildingIsThis, whatResource;
	public float WhatLevel;

	public float IndividualOutput;
	
	public GameObject upgradeMenu;
	public GameObject nextBuilding;
	
	void Start() {
		if(whatBuildingIsThis == "Farm") {
			Controller.foodSupplyRate += IndividualOutput;
		} else if(whatBuildingIsThis == "Lumber Camp") {
			Controller.woodSupplyRate += IndividualOutput;
		} else if(whatBuildingIsThis == "Mine") {
			Controller.metalSupplyRate += IndividualOutput;
		} else if(whatBuildingIsThis == "Quarry") {
			Controller.stoneSupplyRate += IndividualOutput;
		}
	}
	
	void OnMouseOver() {
		//Debug.Log("over resource");
		if(Input.GetMouseButtonDown(0) && GameObject.FindGameObjectWithTag("Menu") == null) {
			Controller.whatWasClicked = gameObject;
			Instantiate(upgradeMenu, Vector3.zero, Quaternion.identity);
		}
	}
	void OnDestroy() {
		if (whatBuildingIsThis == "Farm") {
			Controller.foodSupplyRate -= IndividualOutput;
		} else if (whatBuildingIsThis == "Lumber Camp") {
			Controller.woodSupplyRate -= IndividualOutput;
		} else if (whatBuildingIsThis == "Mine") {
			Controller.metalSupplyRate -= IndividualOutput;
		} else if (whatBuildingIsThis == "Quarry") {
			Controller.stoneSupplyRate -= IndividualOutput;
		}
	}
}
