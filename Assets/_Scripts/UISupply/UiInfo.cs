using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInfo : MonoBehaviour {

	public GameObject InfoPanel;
	private GameObject temp;

	[HideInInspector]
	public string foodsupply, woodsupply, metalsupply, stonesupply, popSupply;

	void Start() {
		InvokeRepeating("IncreaseResources", 0.0f, 1.0f);
	}

	void Update() {
		foodsupply = "Food: " + Controller.SupplyofFood.ToString();
		woodsupply = "Wood: " + Controller.SupplyofWood.ToString();
		metalsupply = "Metal: " + Controller.SupplyofMetal.ToString();
		stonesupply = "Stone: " + Controller.SupplyofStone.ToString();
		popSupply = "Pop: " + Controller.currPopulation.ToString() + "/" + Controller.maxPopulation.ToString();
	}

	void IncreaseResources() {
		Controller.SupplyofFood += Controller.foodSupplyRate;
		Controller.SupplyofWood += Controller.woodSupplyRate;
		Controller.SupplyofMetal += Controller.metalSupplyRate;
		Controller.SupplyofStone += Controller.stoneSupplyRate;
	}

	public void OnClickInfo() {
		if (GameObject.FindGameObjectWithTag("infoPanel") == null) {
;			temp = Instantiate(InfoPanel, transform.position, Quaternion.identity);
		} else {
			Destroy(temp.gameObject);
		}
	}
}
