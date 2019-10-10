using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class fieldCastle : MonoBehaviour {

	void OnMouseOver() {
		if (GameObject.FindGameObjectWithTag("Menu") == null) {
			if (Input.GetMouseButtonDown(0)) {
				//save stats
				//Switch scenes to Castle View
				LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
				levelManager.LoadCastle();
			}
		}
	}
}
