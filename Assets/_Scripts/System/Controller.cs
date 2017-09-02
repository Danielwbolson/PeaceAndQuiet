using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	//global variables
	public static GameObject whatWasClicked;
	public static float foodSupplyRate, metalSupplyRate, woodSupplyRate, stoneSupplyRate;
	public static float SupplyofFood, SupplyofWood, SupplyofMetal, SupplyofStone;
	public static string Difficulty;
	public static bool Blacksmith, Tailor, GreatHall, Warehouse, Castle;
	public static int Population;

	void Start() {
		if (Difficulty == null) {
			Difficulty = "Normal";
		}
		Debug.Log(Difficulty);
		Debug.Log("This worked");

		if(Difficulty == "Easy") {
			SupplyofFood = 400f;
			SupplyofWood = 800f;
			SupplyofMetal = 400f;
			SupplyofStone = 200f;
		}
		else if(Difficulty == "Normal") {
			SupplyofFood = 200f;
			SupplyofWood = 400f;
			SupplyofMetal = 200f;
			SupplyofStone = 100f;
		}
		else if(Difficulty == "Hard") {
			SupplyofFood = 50f;
			SupplyofWood = 200f;
			SupplyofMetal = 50f;
			SupplyofStone = 0f;
		}
		else if(Difficulty == "Fun") {
			SupplyofFood = 10000f;
			SupplyofWood = 10000f;
			SupplyofMetal = 10000f;
			SupplyofStone = 10000f;

		}
	}
}
