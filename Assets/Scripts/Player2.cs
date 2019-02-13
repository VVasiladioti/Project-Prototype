using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {
    
    public float jump;
    public Rigidbody rb;


    private void OnCollisionEnter(Collision collision) {
        if(collision.other.CompareTag("Resources2")) {
           
            collision.other.tag = "Player2";
            collision.other.GetComponent<ResourcesScript>().Target = gameObject;
            Score2.scoreValue += 10;
        }
        else if (collision.other.CompareTag("Player2"))
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
		if (Input.GetButton ("Horizontal2")) {
				rb.AddTorque(Vector3.back * Input.GetAxis("Horizontal2")*50); //10
			}
		    if (Input.GetButton ("Vertical2")) {
				rb.AddTorque(Vector3.right * Input.GetAxis("Vertical2")*50);
			}

            if (Input.GetKey(KeyCode.LeftControl)) {
                 rb.velocity = new Vector3(0, 1, 0) * jump;
            }
            
		}
    }
}

