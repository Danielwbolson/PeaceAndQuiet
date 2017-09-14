using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject DifficultyPanel;
	public GameObject InfoPanel;

	public string startingLevel;

	void Start() {
		GetComponent<SaveManager>().LoadScene();
	}

	public void LoadLevel(string name)
	{
		GetComponent<SaveManager>().SaveScene();
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	public void SpawnDifficultyPanel() {
		DifficultyPanel.SetActive(true);
	}

	public void DeSpawnDifficultyPanel() {
		DifficultyPanel.SetActive(false);
	}

	public void SelectEasy() {
		Controller.Difficulty = "Easy";
		LoadLevel(startingLevel);
	}

	public void SelectNormal() {
		Controller.Difficulty = "Normal";
		LoadLevel(startingLevel);
	}

	public void SelectHard() {
		Controller.Difficulty = "Hard";
		LoadLevel(startingLevel);
	}

	public void SelectInteresting() {
		Controller.Difficulty = "Fun";
		LoadLevel(startingLevel);
	}

	private void OnApplicationQuit() {
		GetComponent<SaveManager>().SaveScene();
	}
}
