using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject background;
	float speed;

	void Awake() {
		speed = 0.1f;
	}

	void Update() {
		ScrollSideways ();
	}

	void ScrollSideways() {
		//get the x & y of the mouse as a ratio
		float mouseX = Input.mousePosition.x / Screen.width;
		float mouseY = Input.mousePosition.y / Screen.height;

		//move the camera
		Vector3 cameraPos = transform.position;

		if (mouseX < 0.20) {
			cameraPos.x -= speed;
		}
		if (mouseX > 0.80) {
			cameraPos.x += speed;
		}

		//clamp
		float bgWidth = background.GetComponent<Renderer>().bounds.extents.x;
		float bgHeight = background.GetComponent<Renderer>().bounds.extents.y;

		transform.position = new Vector3 (
			Mathf.Clamp (cameraPos.x, background.transform.position.x - bgWidth/2, background.transform.position.x + bgWidth/2),
			Mathf.Clamp (cameraPos.y, background.transform.position.y - bgHeight/2, background.transform.position.y + bgHeight/2),
			transform.position.z
		);
	}
}
