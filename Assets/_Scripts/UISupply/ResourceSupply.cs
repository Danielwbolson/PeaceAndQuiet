using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSupply : MonoBehaviour {

	[HideInInspector]
	public string foodsupply, woodsupply, metalsupply, stonesupply;

	void Start() {
		InvokeRepeating("IncreaseResources", 0.0f, 1.0f);

	}

	void Update() {
		foodsupply = "Food: " + Controller.SupplyofFood.ToString();
		woodsupply = "Wood: " + Controller.SupplyofWood.ToString();
		metalsupply = "Metal: " + Controller.SupplyofMetal.ToString();
		stonesupply = "Stone: " + Controller.SupplyofStone.ToString();
	}

	void IncreaseResources() {
		Controller.SupplyofFood += Controller.foodSupplyRate;
		Controller.SupplyofWood += Controller.woodSupplyRate;
		Controller.SupplyofMetal += Controller.metalSupplyRate;
		Controller.SupplyofStone += Controller.stoneSupplyRate;
	}
}
