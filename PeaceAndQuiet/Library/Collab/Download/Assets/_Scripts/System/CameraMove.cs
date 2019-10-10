using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	
	Camera cam;
	bool isPanning;
	Vector3 origPos;
	private float xmin, xmax, ymin, ymax;
	
	void Start() {
		cam = Camera.main;
		xmax = 10;
		xmin = -xmax;
		ymax = 9f;
		ymin = -ymax;
	}
	// Update is called once per frame
	void Update() {
		if(Input.GetAxis("Mouse ScrollWheel") > 0) {
			cam.orthographicSize -= 1; //zoom in
		} else if(Input.GetAxis("Mouse ScrollWheel") < 0) {
			cam.orthographicSize += 1; //zoom out
		}
		
		if(cam.orthographicSize < 3)
			cam.orthographicSize = 3; //min
		else if(cam.orthographicSize > 12)
			cam.orthographicSize = 12; //max
	
		if(!Input.GetMouseButton(1)) {
			isPanning = false;
		}
		
		if(Input.GetMouseButtonDown(1)) {
			origPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
			origPos = cam.ScreenToWorldPoint(origPos);
			Debug.Log(origPos);
			isPanning = true;
		}
	}
	
	void LateUpdate() {
		if(isPanning) {
			Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
			pos = cam.ScreenToWorldPoint(pos);
			
			Vector3 movePos = origPos - pos;
			
			Vector3 temp = transform.position + movePos;
			temp.x = Mathf.Clamp(temp.x, xmin, xmax);
			temp.y = Mathf.Clamp(temp.y, ymin, ymax);
			transform.position = temp;
		}
	}
}
