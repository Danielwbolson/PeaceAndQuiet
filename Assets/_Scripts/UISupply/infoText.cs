using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class infoText : MonoBehaviour {

	public string difficulty, farmNum, woodNum, metalNum, stoneNum;

	// Use this for initialization
	void Update () {
		difficulty = "Difficulty: " + Controller.Difficulty.ToString() + "\n\n";
		farmNum = "Farms: " + Controller.NumOfFarms.ToString() + "\n";
		woodNum = "Lumber Camps: " + Controller.NumOfLumberCamps.ToString() + "\n";
		metalNum = "Mines: " + Controller.NumOfMines.ToString() + "\n";
		stoneNum = "Quarries: " + Controller.NumOfQuarries.ToString();

		GetComponent<Text>().text = difficulty + farmNum + woodNum + metalNum + stoneNum;
	}
}
