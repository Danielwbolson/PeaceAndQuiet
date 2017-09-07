using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject DifficultyPanel;
	public GameObject InfoPanel;

	void Start() {
		if (SceneManager.GetActiveScene().name == "Field") {
			GetComponent<SaveManager>().LoadScene();
		}
	}

	public void LoadField()
	{
		SceneManager.LoadScene("Field", LoadSceneMode.Single);
	}

	public void LoadCastle()
	{
		GetComponent<SaveManager>().SaveScene();
		SceneManager.LoadScene("City", LoadSceneMode.Single);
	}

	public void LoadMap()
	{
		
	}

	public void LoadMenu()
	{
		
	}

	public void SpawnDifficultyPanel() {
		DifficultyPanel.SetActive(true);
	}

	public void DeSpawnDifficultyPanel() {
		DifficultyPanel.SetActive(false);
	}

	public void SelectEasy() {
		Controller.Difficulty = "Easy";
		LoadField();
	}

	public void SelectNormal() {
		Controller.Difficulty = "Normal";
		LoadField();
	}

	public void SelectHard() {
		Controller.Difficulty = "Hard";
		LoadField();
	}

	public void SelectInteresting() {
		Controller.Difficulty = "Fun";
		LoadField();
	}

	private void OnApplicationQuit() {
		GetComponent<SaveManager>().SaveScene();
	}
}
