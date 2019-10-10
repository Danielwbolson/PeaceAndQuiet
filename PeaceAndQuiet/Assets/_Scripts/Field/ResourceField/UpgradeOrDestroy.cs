using UnityEngine;
using System.Collections;

public class UpgradeOrDestroy : MonoBehaviour {

	ResourceTile clicked;
	BuildingCosts clickCost;
	bool enough;

	void Start() {
		clicked = Controller.whatWasClicked.GetComponent<ResourceTile>();
		clickCost = Controller.whatWasClicked.GetComponent<BuildingCosts>();
	}

	void Update() {
		if(Input.GetMouseButtonDown(1)) {
			Destroy(gameObject);
		}
	}

	public void OnClickUpgrade() {
		enough = CheckCost(clickCost.UFoodCost, clickCost.UWoodCost, clickCost.UMetalCost, clickCost.UStoneCost);
		if(enough) {
			if(clicked.nextBuilding != null) {
				NextBuilding();
				Destroy(transform.root.gameObject);
				Destroy(Controller.whatWasClicked);
			}
		} else {
			YouCannotAffordThis();
		}
	}

	public void OnClickDestroy() {
		enough = CheckCost(clickCost.DFoodCost, clickCost.DWoodCost, clickCost.DMetalCost, clickCost.DStoneCost);
		if(enough) {
			Controller.whatWasClicked.transform.parent.GetComponent<emptyField>().isEmpty = true;
			clicked.transform.parent.transform.GetComponent<SpriteRenderer>().enabled = true;
			Destroy(transform.root.gameObject); //Destroys the menu
			Destroy(Controller.whatWasClicked); //Destroys the field
		} else {
			YouCannotAffordThis();
		}
	}

	void NextBuilding() {
		GameObject nextBuilding = clicked.nextBuilding;
		GameObject Upgrade = Instantiate(nextBuilding, Controller.whatWasClicked.transform.position, Quaternion.identity) as GameObject;
		Upgrade.transform.parent = Controller.whatWasClicked.transform.parent;
	}

	public bool CheckCost(float FCost, float WCost, float MCost, float SCost) {
		if(FCost <= Controller.SupplyofFood && WCost <= Controller.SupplyofWood && MCost <= Controller.SupplyofMetal && SCost <= Controller.SupplyofStone) {
			Controller.SupplyofFood -= FCost;
			Controller.SupplyofWood -= WCost;
			Controller.SupplyofMetal -= MCost;
			Controller.SupplyofStone -= SCost;
			return true;
		} else {
			return false;
		}
	}

	void YouCannotAffordThis() {
		Debug.Log("You cannot afford this you hoser!");
	}
}
