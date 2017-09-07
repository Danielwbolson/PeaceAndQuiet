using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEditor;

public class SaveManager : MonoBehaviour {

	int numOfResourceTiles;
	int numOfEmptyFields;

	public void SaveScene() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file1 = File.Create(Application.persistentDataPath + "/ResourceTileData.dat");
		FileStream file2 = File.Create(Application.persistentDataPath + "/EmptyFieldData.dat");

		ResourceTile[] resourceTiles = FindObjectsOfType<ResourceTile>();
		emptyField[] emptyFields = FindObjectsOfType<emptyField>();

		numOfResourceTiles = resourceTiles.Length;
		numOfEmptyFields = emptyFields.Length;

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
			i++;
		}

		bf.Serialize(file1, resourceData);
		file1.Close();

		Debug.Log("Success");
	}

	public void LoadScene() {
		if (File.Exists(Application.persistentDataPath + "/ResourceTileData.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/ResourceTileData.dat", FileMode.Open);

			List<ResourceFieldData> resourceData = (List<ResourceFieldData>)bf.Deserialize(file);

			Debug.Log(resourceData.Count);

			numOfResourceTiles = resourceData.Count;

			for (int i = 0; i < numOfResourceTiles; i++) {
				Vector3 location = new Vector3(resourceData[i].xpos, resourceData[i].ypos, resourceData[i].zpos);
				GameObject temp = Instantiate(AssetDatabase.LoadAssetAtPath("Assets/_Prefabs/Field/Level1/" + resourceData[i].whatBuildingisThis + ".prefab", typeof(GameObject)), location, Quaternion.identity) as GameObject;
			}
			file.Close();
		}
	}
}

[Serializable]
class ResourceFieldData {
	public float xpos, ypos, zpos;
	public string whatBuildingisThis;
	public int numOfResourceTiles;
}

[Serializable]
class CityBuildingData {
	public float xpos, ypos, zpos;
	public string whatBuildingisThis;
	public int numOfBuildings;
}

[Serializable]
class Resources {
	public float FoodSupply, WoodSupply, MetalSupply, StoneSupply;
	public float foodRate, woodRate, metalRate, stoneRate;
	public int numOfFarms, numofLumberCamps, numofMines, numofQuarries;
}
