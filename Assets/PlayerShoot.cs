using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	[SerializeField] private GameObject shotPrefab;
	[SerializeField] private Camera vrCamera;
	private Camera mcamera;

	// Use this for initialization
	void Start () {
		if (vrCamera == null || !vrCamera.isActiveAndEnabled) {
			mcamera = GetComponent<Camera> ();
		} else {
			mcamera = vrCamera;
		}
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			// instantiate the prefab
            var shot = Instantiate(shotPrefab) as GameObject;
            var current = mcamera.transform.position;
			shot.transform.position = new Vector3(current.x, current.y, current.z);
            shot.transform.rotation = mcamera.transform.rotation;
		}
	}
}
