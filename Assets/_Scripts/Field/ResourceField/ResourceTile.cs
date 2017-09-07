using UnityEngine;
using System.Collections;

public class ResourceTile : MonoBehaviour {

	public string whatBuildingIsThis, whatResource;
	public float WhatLevel;

	public float IndividualOutput;

	public int plusPopulation = 4;
	
	public GameObject upgradeMenu;
	public GameObject nextBuilding;
	public LayerMask layerMask;
	public bool wasBuilt = false;

	void Start() {
		if (!wasBuilt) {
			Vector2 location = new Vector2(1f, 1f);
			Collider2D collider = Physics2D.OverlapBox(transform.position, location, 0f, LayerMask.GetMask("EmptyField"), -Mathf.Infinity, Mathf.Infinity);
			//Debug.Log(LayerMask.LayerToName(LayerMask.GetMask("EmptyField")));
			if (collider.gameObject != null) {
				transform.SetParent(collider.gameObject.transform);
				transform.parent.GetComponent<emptyField>().isEmpty = false;
			}
		}
		if (wasBuilt) {
			if (whatResource == "food") {
				Controller.foodSupplyRate += IndividualOutput;
				Controller.NumOfFarms += 1;
			} else if (whatResource == "wood") {
				Controller.woodSupplyRate += IndividualOutput;
				Controller.NumOfLumberCamps += 1;
			} else if (whatResource == "metal") {
				Controller.metalSupplyRate += IndividualOutput;
				Controller.NumOfMines += 1;
			} else if (whatResource == "stone") {
				Controller.stoneSupplyRate += IndividualOutput;
				Controller.NumOfQuarries += 1;
			}
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
		if (whatResource == "food") {
			Controller.foodSupplyRate -= IndividualOutput;
		} else if (whatResource == "wood") {
			Controller.woodSupplyRate -= IndividualOutput;
		} else if (whatResource == "metal") {
			Controller.metalSupplyRate -= IndividualOutput;
		} else if (whatResource == "stone") {
			Controller.stoneSupplyRate -= IndividualOutput;
		}
	}
}
