﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FieldName : MonoBehaviour {

	private GameObject upgradeMenu;
	
	void Start() {
		upgradeMenu = this.transform.root.gameObject;
		this.GetComponent<Text>().text = upgradeMenu.GetComponent<BuildingStats>().buildingInfo.ToString();
	}
}
