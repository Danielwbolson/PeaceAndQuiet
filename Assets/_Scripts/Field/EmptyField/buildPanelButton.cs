using UnityEngine;
using System.Collections;

public class buildPanelButton : MonoBehaviour {

	public GameObject ResourceBuilding;
	
	public void OnClickBuilding() {
		if (CheckBuildCosts()) {
			GameObject fieldBuilding = Instantiate(ResourceBuilding, Controller.whatWasClicked.transform.position, Quaternion.identity) as GameObject;
			fieldBuilding.transform.parent = Controller.whatWasClicked.transform;

			fieldBuilding.transform.parent.GetComponent<emptyField>().isEmpty = false;
			fieldBuilding.transform.parent.GetComponent<SpriteRenderer>().enabled = false;
			Destroy(this.transform.root.gameObject);
		} else {
			Debug.Log("You cannot afford this building.");
		}
	}

	bool CheckBuildCosts() {
		float FCost = ResourceBuilding.GetComponent<FirstBuildCost>().BFoodCost;
		float WCost = ResourceBuilding.GetComponent<FirstBuildCost>().BWoodCost;
		float MCost = ResourceBuilding.GetComponent<FirstBuildCost>().BMetalCost;
		float SCost = ResourceBuilding.GetComponent<FirstBuildCost>().BStonecost;

		if(FCost <= Controller.SupplyofFood && WCost <= Controller.SupplyofWood && MCost <= Controller.SupplyofMetal && SCost <= Controller.SupplyofStone) {
			Controller.SupplyofFood -= FCost;
			Controller.SupplyofWood -= WCost;
			Controller.SupplyofMetal -= MCost;
			Controller.SupplyofStone -= SCost;
			return true;
		}else { Debug.Log("You do not have the necessary resources to construct this building.");
			return false;
		}
	}

}
