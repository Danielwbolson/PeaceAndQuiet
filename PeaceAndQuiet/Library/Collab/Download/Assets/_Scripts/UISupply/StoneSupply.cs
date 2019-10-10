using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoneSupply : MonoBehaviour {

	private GameObject ResourceSupply;

	void Start() {
		ResourceSupply = transform.root.gameObject;
	}

	void Update() {
		this.GetComponent<Text>().text = ResourceSupply.GetComponent<ResourceSupply>().stonesupply;
	}
}
