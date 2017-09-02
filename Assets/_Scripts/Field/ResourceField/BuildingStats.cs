using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingStats : MonoBehaviour {

	ResourceTile building;
	BuildingCosts buildCost;
	
	[HideInInspector]
	public string
		buildingName, buildingInfo, level, currStats, nextStats, cost;
	
	// Use this for initialization
	void Start() {
		building = Controller.whatWasClicked.GetComponent<ResourceTile>();
		buildCost = Controller.whatWasClicked.GetComponent<BuildingCosts>();
		buildingName = building.whatBuildingIsThis;
		
		buildingInfo = buildingName + " (LV." + building.WhatLevel + ")";
		
		currStats = "This " + buildingName + " produces " + building.IndividualOutput.ToString() + " " + building.whatResource.ToString() + ".";
		
		if(building.nextBuilding != null) {
			nextStats = "Upgraded, this " + buildingName + " will produce " + (building.IndividualOutput + 
				building.nextBuilding.GetComponent<ResourceTile>().IndividualOutput).ToString() + " " + building.whatResource.ToString() + ".";
		} else {
			nextStats = "This " + buildingName + " is fully upgraded.";
		}
		
		cost = "To upgrade this " + buildingName + " you will need:\n" + 
			buildCost.UFoodCost + " Food\n" +
			buildCost.UWoodCost + " Wood\n" +
			buildCost.UStoneCost + " Stone\n" +
			buildCost.UMetalCost + " Metal";
	}
}
