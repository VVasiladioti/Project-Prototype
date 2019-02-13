using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

    public float jump;
    private Rigidbody rb;


    private void OnCollisionEnter(Collision collision) {
        if(collision.other.CompareTag("Resources1")) {
            
            collision.other.tag = "Player1";
            collision.other.GetComponent<ResourcesScript>().Target = gameObject;
            Score1.scoreValue += 10;
        }
        else if (collision.other.CompareTag("Player1"))
        {
            collision.other.GetComponent<Rigidbody>().AddForce((collision.other.transform.position - transform.position).normalized * 100f);
    
        }
    }
    // Start is called before the first frame update
    void Start() {
       rb = GetComponent<Rigidbody> (); 
    }

    // Update is called once per frame
    void Update() {
        UpdateKeys();
    }

private void UpdateKeys() {
	if (rb != null) {
		if (Input.GetButton ("Horizontal1")) {
				rb.AddTorque(Vector3.back * Input.GetAxis("Horizontal1")*50); //10 Horizontal
			}
		    if (Input.GetButton ("Vertical1")) {
				rb.AddTorque(Vector3.right * Input.GetAxis("Vertical1")*50);
			}

            if (Input.GetKey(KeyCode.Space)) {
                 rb.velocity = new Vector3(0, 1, 0) * jump;
            }
            
		}
    }
}
