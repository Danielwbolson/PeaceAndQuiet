using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIPopulation : MonoBehaviour {

	private GameObject ResourceSupply;

	void Start() {
		ResourceSupply = transform.root.gameObject;
	}
		// Update is called once per frame
		void Update () {
			GetComponent<Text>().text = ResourceSupply.GetComponent<UiInfo>().popSupply.ToString();
		}
}
