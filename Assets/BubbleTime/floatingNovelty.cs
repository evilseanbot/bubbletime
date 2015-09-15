using UnityEngine;
using System.Collections;

public class floatingNovelty : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        rb.position = new Vector3(
            Random.Range(-100f, 100f),
            Random.Range(35f, 45f),
            100
        );

        rb.velocity = new Vector3(
            Random.Range(-2, 2),
            Random.Range(-0.2f, 0.2f),
            -2
        );

        rb.angularVelocity = new Vector3(
            Random.Range(-0.25f, 0.25f),
            Random.Range(-0.25f, 0.25f),
            Random.Range(-0.25f, 0.25f)
        );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
