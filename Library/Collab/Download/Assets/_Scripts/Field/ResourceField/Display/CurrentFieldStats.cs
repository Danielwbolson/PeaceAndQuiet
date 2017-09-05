using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentFieldStats : MonoBehaviour {
	
	private GameObject upgradeMenu;
	
	void Start() {
		upgradeMenu = this.transform.root.gameObject;
		this.GetComponent<Text>().text = upgradeMenu.GetComponent<BuildingStats>().currStats;
	}
}
