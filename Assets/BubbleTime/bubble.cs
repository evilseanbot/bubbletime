using UnityEngine;
using System.Collections;

public class bubble : MonoBehaviour {
    public float size = 0;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        size = Mathf.Min(
            Random.Range(0.01f, 0.3f),
            Random.Range(0.01f, 0.3f),
            Random.Range(0.01f, 0.3f)
        );
    }
	
	// Update is called once per frame
	void Update () {
        grow();

        rb.velocity += new Vector3(
             Random.Range(-0.005f, 0.005f),
             0.0025f,
             Random.Range(-0.005f, 0.005f)
        );

        /*transform.position = new Vector3(
            transform.position.x,
            transform.position.y + 0.01f,
            transform.position.z
        );*/

        rb.angularVelocity += new Vector3(
            Random.Range(-0.5f, 0.5f),
            Random.Range(-0.5f, 0.5f),
            Random.Range(-0.5f, 0.5f)
        );
    }

    void grow() {
        if (transform.localScale.x < size) {
            transform.localScale = new Vector3(
                transform.localScale.x + 0.001f,
                transform.localScale.x + 0.001f,
                transform.localScale.x + 0.001f
            );
            rb.velocity /= 1.02f;
            /*rb.velocity = new Vector3(
                rb.velocity.x * 0.99f,
                rb.velocity.y,
                rb.velocity.z * 0.99f
            );*/
        }
    }

    public void addVelocity(Vector3 addedVelocity){
        rb = GetComponent<Rigidbody>();
        rb.velocity += addedVelocity;
    }
}
