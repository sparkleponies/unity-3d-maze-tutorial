using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	[SerializeField] private GameObject shotPrefab;
	private Camera mcamera;

	// Use this for initialization
	void Start () {
		mcamera = GetComponent<Camera>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			// instantiate the prefab
            var shot = Instantiate(shotPrefab) as GameObject;
            var current = mcamera.transform.position;
            shot.transform.position = new Vector3(current.x, 0.32f, current.z);
            shot.transform.rotation = mcamera.transform.rotation;
		}
	}
}
