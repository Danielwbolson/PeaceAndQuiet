using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(GetComponent<CityBuilding>().wasBuilt)
			Controller.troopProductionMultiplier += 0.1f;
	}

	private void OnDestroy() {  
		if(Controller.troopProductionMultiplier > 1)
			Controller.troopProductionMultiplier -= 0.1f;
	}
}
