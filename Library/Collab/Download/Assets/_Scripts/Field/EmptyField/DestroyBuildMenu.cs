using UnityEngine;
using System.Collections;

public class DestroyBuildMenu : MonoBehaviour {

	void Update() {
		if(Input.GetMouseButtonDown(1)) {
			Destroy(gameObject);
		}
	}
}
