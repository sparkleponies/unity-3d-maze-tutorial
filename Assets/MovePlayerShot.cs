using UnityEngine;
using System.Collections;

public class MovePlayerShot : MonoBehaviour {
    public float speed = 2f;
    public float length = 5f;
    private Vector3 start;
    [SerializeField] private GameObject explosion;

	// Use this for initialization
	void Start () {
        start = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, speed * Time.deltaTime);
        float goneFor = (transform.position - start).magnitude;
        if (goneFor > length) {
            Destroy(this.gameObject);     
        }
    }

    void OnTriggerEnter(Collider other) {
        var player = other.GetComponent<PlayerCharacter>();
        if (player == null) {
            Destroy(this.gameObject);  
            var expl = Instantiate(explosion) as GameObject;
            expl.transform.position = transform.position;
            transform.Translate(0, 0, - speed * Time.deltaTime);
        }
    }
}
