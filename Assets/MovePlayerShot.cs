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
            Kill();    
        }
    }

    void OnTriggerEnter(Collider other) {
        var player = other.GetComponent<PlayerCharacter>();
        if (player == null) {
            Kill();  
        }
    }

    void Kill() {
        Destroy(this.gameObject);
        var expl = Instantiate(explosion) as GameObject;
        expl.transform.rotation = transform.rotation;
        expl.transform.position = transform.position;
        expl.transform.Translate(0, 0, - 5 * speed * Time.deltaTime);
    }
}
