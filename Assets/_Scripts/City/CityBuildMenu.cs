using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBuildMenu : MonoBehaviour {

	public GameObject House, Barracks;

	public void OnClickHouse() {
		if (CheckBuildCosts(House)) {
			//Create a house and mark field as empty
			Controller.whatWasClicked.GetComponent<emptyField>().isEmpty = false;
			GameObject building = Instantiate(House, Controller.whatWasClicked.transform.position, Quaternion.identity);
			//raise population limit
			building.transform.parent = Controller.whatWasClicked.transform;

			building.transform.parent.GetComponent<emptyField>().isEmpty = false;
			building.transform.parent.GetComponent<SpriteRenderer>().enabled = false;
			Destroy(this.transform.root.gameObject);
		}
	}

	public void OnClickBarracks() {
		if (CheckBuildCosts(Barracks)) {
			//Create a Barracks and mark field as empty
			Controller.whatWasClicked.GetComponent<emptyField>().isEmpty = false;
			GameObject building = Instantiate(Barracks, Controller.whatWasClicked.transform.position, Quaternion.identity);
			Destroy(this.transform.root.gameObject);

			building.transform.parent = Controller.whatWasClicked.transform;

			building.transform.parent.GetComponent<emptyField>().isEmpty = false;
			building.transform.parent.GetComponent<SpriteRenderer>().enabled = false;
		}
	}

	bool CheckBuildCosts(GameObject ResourceBuilding) {
		float FCost = ResourceBuilding.GetComponent<FirstBuildCost>().BFoodCost;
		float WCost = ResourceBuilding.GetComponent<FirstBuildCost>().BWoodCost;
		float MCost = ResourceBuilding.GetComponent<FirstBuildCost>().BMetalCost;
		float SCost = ResourceBuilding.GetComponent<FirstBuildCost>().BStonecost;

		if (FCost <= Controller.SupplyofFood && WCost <= Controller.SupplyofWood && MCost <= Controller.SupplyofMetal && SCost <= Controller.SupplyofStone) {
			Controller.SupplyofFood -= FCost;
			Controller.SupplyofWood -= WCost;
			Controller.SupplyofMetal -= MCost;
			Controller.SupplyofStone -= SCost;
			return true;
		} else {
			Debug.Log("You do not have the necessary resources to construct this building.");
			return false;
		}
	}
}
