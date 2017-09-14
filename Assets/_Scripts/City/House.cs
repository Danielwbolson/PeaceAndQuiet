using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(GetComponent<CityBuilding>().wasBuilt)
			Controller.maxPopulation += 5;
	}

	private void OnDestroy() {
		Controller.maxPopulation -= 5;
	}
}
