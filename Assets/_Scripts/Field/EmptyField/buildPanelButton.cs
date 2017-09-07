using UnityEngine;
using System.Collections;

public class buildPanelButton : MonoBehaviour {

	public GameObject ResourceBuilding;
	float FCost, WCost, MCost, SCost;
	int populationHit;

	public void OnClickBuilding() {
		if (CheckBuildCosts()) {
			if (CheckPopulation()) {
				GameObject fieldBuilding = Instantiate(ResourceBuilding, Controller.whatWasClicked.transform.position, Quaternion.identity) as GameObject;
				fieldBuilding.GetComponent<ResourceTile>().wasBuilt = true;
				fieldBuilding.transform.parent = Controller.whatWasClicked.transform;

				fieldBuilding.transform.parent.GetComponent<emptyField>().isEmpty = false;
				fieldBuilding.transform.parent.GetComponent<SpriteRenderer>().enabled = false;

				updateStats();

				Destroy(this.transform.root.gameObject);
			} else {
				Debug.Log("You must build more houses!");
			}
		} else {
			Debug.Log("You do not have the necessary resources to construct this building.");
		}
	}

	bool CheckBuildCosts() {
		FCost = ResourceBuilding.GetComponent<FirstBuildCost>().BFoodCost;
		WCost = ResourceBuilding.GetComponent<FirstBuildCost>().BWoodCost;
		MCost = ResourceBuilding.GetComponent<FirstBuildCost>().BMetalCost;
		SCost = ResourceBuilding.GetComponent<FirstBuildCost>().BStonecost;

		if(FCost <= Controller.SupplyofFood && WCost <= Controller.SupplyofWood && MCost <= Controller.SupplyofMetal && SCost <= Controller.SupplyofStone) {
			return true;
		}else { 
			return false;
		}
	}

	bool CheckPopulation() {
		populationHit = ResourceBuilding.GetComponent<ResourceTile>().plusPopulation;
		if(Controller.currPopulation + populationHit <= Controller.maxPopulation) {
			return true;
		} else {
			return false;
		}
	}

	void updateStats() {
		Controller.SupplyofFood -= FCost;
		Controller.SupplyofWood -= WCost;
		Controller.SupplyofMetal -= MCost;
		Controller.SupplyofStone -= SCost;

		Controller.currPopulation += populationHit;
	}
}

