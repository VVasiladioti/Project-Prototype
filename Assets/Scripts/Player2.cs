using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {
    [SerializeField]
    private float speed;

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
        if (Input.GetKey(KeyCode.UpArrow)) {
            Vector3 temp = transform.position;
            temp.z += speed * Time.deltaTime;
            transform.position = temp;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp; 
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            Vector3 temp = transform.position;
            temp.z -= speed * Time.deltaTime;
            transform.position = temp;
        }
        if (Input.GetKey(KeyCode.RightControl)) {
           rb.velocity = new Vector3(0, 1, 0) * jump;
        }
    }
     
}

