using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UiInfo : MonoBehaviour {

	public GameObject InfoPanel;
	private GameObject temp;
	public LevelManager levelManager;

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

		if (Input.GetMouseButtonDown(1)) {
			temp = GameObject.FindGameObjectWithTag("infoPanel");
			if (temp != null) {
				Destroy(temp.gameObject);
			}
		}
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

	public void OnClickReset() {
		levelManager.GetComponent<Controller>().InitialResources();
		if (SceneManager.GetActiveScene().name == "Field") {
			foreach (GameObject RST in GameObject.FindGameObjectsWithTag("ResourceTile")) {
				RST.transform.parent.GetComponent<emptyField>().isEmpty = true;
				Destroy(RST);
			}
		}
		else if(SceneManager.GetActiveScene().name == "City") {
			foreach(GameObject CB in GameObject.FindGameObjectsWithTag("CityBuilding")) {
				CB.transform.parent.GetComponent<emptyField>().isEmpty = true;
				Destroy(CB);
			}
		}
	}
}
