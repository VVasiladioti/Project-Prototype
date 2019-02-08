using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {
    [SerializeField]
    private float speed;
    public float jump;
    public Rigidbody rb;

    private void OnCollisionEnter(Collision collision) {
        if(collision.other.CompareTag("Resources1")) {
            
            collision.other.tag = "Player1";
            collision.other.GetComponent<ResourcesScript>().Target = gameObject;
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
        if (Input.GetKey(KeyCode.W)) {
            Vector3 temp = transform.position;
            temp.z += speed * Time.deltaTime;
            transform.position = temp;
        }
        if (Input.GetKey(KeyCode.A)) {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp; 
        }
        if (Input.GetKey(KeyCode.D)) {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }
        if (Input.GetKey(KeyCode.S)) {
            Vector3 temp = transform.position;
            temp.z -= speed * Time.deltaTime;
            transform.position = temp;
        }
        if (Input.GetKey(KeyCode.Space)) {
           rb.velocity = new Vector3(0, 1, 0) * jump;
        }
    }
     
}
