using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public class SaveManager : MonoBehaviour {

	int numOfResourceTiles;
	int numofCityBuildings;

	public void SaveScene() {
		BinaryFormatter bf = new BinaryFormatter();

		if (SceneManager.GetActiveScene().name == "Field") {
			//Save by scene and then have non scene specific things at the end
			FileStream resourceTileFile = File.Create(Application.persistentDataPath + "/ResourceTileData.dat");

			ResourceTile[] resourceTiles = FindObjectsOfType<ResourceTile>();
			numOfResourceTiles = resourceTiles.Length;


			List<ResourceFieldData> resourceData = new List<ResourceFieldData>();

			for (int k = 0; k < numOfResourceTiles; k++) {
				ResourceFieldData RFD = new ResourceFieldData();

				resourceData.Add(RFD);
			}

			int i = 0;
			foreach (ResourceTile RST in resourceTiles) {
				resourceData[i].xpos = RST.transform.position.x;
				resourceData[i].ypos = RST.transform.position.y;
				resourceData[i].zpos = RST.transform.position.z;

				resourceData[i].whatBuildingisThis = RST.whatBuildingIsThis;
				resourceData[i].numOfResourceTiles = numOfResourceTiles;
				resourceData[i].wasBuilt = false;
				i++;
			}

			bf.Serialize(resourceTileFile, resourceData);
			resourceTileFile.Close();
		}

		if (SceneManager.GetActiveScene().name == "City") {

			FileStream cityBuildingsFile = File.Create(Application.persistentDataPath + "/CityBuildingData.dat");

			CityBuilding[] cityBuildings = FindObjectsOfType<CityBuilding>();
			numofCityBuildings = cityBuildings.Length;

			List<CityBuildingData> citybuildingData = new List<CityBuildingData>();

			for (int k = 0; k < numofCityBuildings; k++) {
				CityBuildingData CBD = new CityBuildingData();
				 
				citybuildingData.Add(CBD);
			}

			int i = 0;
			foreach (CityBuilding CBD in cityBuildings) {
				citybuildingData[i].xpos = CBD.transform.position.x;
				citybuildingData[i].ypos = CBD.transform.position.y;
				citybuildingData[i].zpos = CBD.transform.position.z;

				citybuildingData[i].whatBuildingisThis = CBD.whatBuildingIsThis;
				citybuildingData[i].numOfBuildings = numofCityBuildings;
				citybuildingData[i].wasBuilt = false;
				i++;
			}
			bf.Serialize(cityBuildingsFile, citybuildingData);
			cityBuildingsFile.Close();

		}

		FileStream resourcesFile = File.Create(Application.persistentDataPath + "/Resources.dat");

		Resources resources = new Resources {
			foodRate = Controller.foodSupplyRate,
			woodRate = Controller.woodSupplyRate,
			metalRate = Controller.metalSupplyRate,
			stoneRate = Controller.stoneSupplyRate,

			FoodSupply = Controller.SupplyofFood,
			WoodSupply = Controller.SupplyofWood,
			MetalSupply = Controller.SupplyofMetal,
			StoneSupply = Controller.SupplyofStone,

			numOfFarms = Controller.NumOfFarms,
			numofLumberCamps = Controller.NumOfLumberCamps,
			numofMines = Controller.NumOfMines,
			numofQuarries = Controller.NumOfQuarries,

			currPopulation = Controller.currPopulation,
			maxPopulation = Controller.maxPopulation,
			troopProductionMultiplier = Controller.troopProductionMultiplier
		};
		bf.Serialize(resourcesFile, resources);
		resourcesFile.Close();

		Debug.Log("Successfully saved");
	}

	public void LoadScene() {
		BinaryFormatter bf = new BinaryFormatter();
		if (SceneManager.GetActiveScene().name == "Field") {
			if (File.Exists(Application.persistentDataPath + "/ResourceTileData.dat")) {
				FileStream resourceTileFile = File.Open(Application.persistentDataPath + "/ResourceTileData.dat", FileMode.Open);

				List<ResourceFieldData> resourceData = (List<ResourceFieldData>)bf.Deserialize(resourceTileFile);

				numOfResourceTiles = resourceData.Count;

				for (int i = 0; i < numOfResourceTiles; i++) {
					Vector3 location = new Vector3(resourceData[i].xpos, resourceData[i].ypos, resourceData[i].zpos);
					GameObject temp = Instantiate(AssetDatabase.LoadAssetAtPath("Assets/_Prefabs/Field/Level1/" + resourceData[i].whatBuildingisThis + ".prefab", typeof(GameObject)), location, Quaternion.identity) as GameObject;
					temp.GetComponent<ResourceTile>().wasBuilt = resourceData[i].wasBuilt;
				}
				resourceTileFile.Close();
			}
		}
		if(SceneManager.GetActiveScene().name == "City") {
			if(File.Exists(Application.persistentDataPath + "/CityBuildingData.dat")) {
				FileStream cityBuildingFile = File.Open(Application.persistentDataPath + "/CityBuildingData.dat", FileMode.Open);

				List<CityBuildingData> cityData = (List<CityBuildingData>)bf.Deserialize(cityBuildingFile);

				numofCityBuildings = cityData.Count;

				for (int i = 0; i < numofCityBuildings; i++) {
					Vector3 location = new Vector3(cityData[i].xpos, cityData[i].ypos, cityData[i].zpos);
					GameObject temp = Instantiate(AssetDatabase.LoadAssetAtPath("Assets/_Prefabs/City/" + cityData[i].whatBuildingisThis + ".prefab", typeof(GameObject)), location, Quaternion.identity) as GameObject;
					temp.GetComponent<CityBuilding>().wasBuilt = cityData[i].wasBuilt;
				}
				cityBuildingFile.Close();
			}
		}
		if (File.Exists(Application.persistentDataPath + "/Resources.dat")) {
			FileStream file = File.Open(Application.persistentDataPath + "/Resources.dat", FileMode.Open);

			Resources resources = (Resources)bf.Deserialize(file);

			Controller.foodSupplyRate = resources.foodRate;
			Controller.woodSupplyRate = resources.woodRate;
			Controller.metalSupplyRate = resources.metalRate;
			Controller.stoneSupplyRate = resources.stoneRate;

			Controller.SupplyofFood = resources.FoodSupply;
			Controller.SupplyofWood = resources.WoodSupply;
			Controller.SupplyofMetal = resources.MetalSupply;
			Controller.SupplyofStone = resources.StoneSupply;

			Controller.NumOfFarms = resources.numOfFarms;
			Controller.NumOfLumberCamps = resources.numofLumberCamps;
			Controller.NumOfMines = resources.numofMines;
			Controller.NumOfQuarries = resources.numofQuarries;

			Controller.maxPopulation = resources.maxPopulation;
			Controller.currPopulation = resources.currPopulation;
			Controller.troopProductionMultiplier = resources.troopProductionMultiplier;

			file.Close();
		}
		Debug.Log("Successfully Loaded");
	}
}

[Serializable]
class ResourceFieldData {
	public float xpos, ypos, zpos;
	public string whatBuildingisThis;
	public int numOfResourceTiles;
	public bool wasBuilt;
}

[Serializable]
class CityBuildingData {
	public float xpos, ypos, zpos;
	public string whatBuildingisThis;
	public int numOfBuildings;
	public bool wasBuilt;
}

[Serializable]
class Resources {
	public float FoodSupply, WoodSupply, MetalSupply, StoneSupply;
	public float foodRate, woodRate, metalRate, stoneRate;
	public int numOfFarms, numofLumberCamps, numofMines, numofQuarries;
	public int currPopulation, maxPopulation;
	public float troopProductionMultiplier;
}
