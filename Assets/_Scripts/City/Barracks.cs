using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(GetComponent<CityBuilding>().wasBuilt)
			Controller.troopProductionMultiplier += 1.1f; 
	}

	private void OnDestroy() { 
		Controller.troopProductionMultiplier /= 1.1f;
	}
}
