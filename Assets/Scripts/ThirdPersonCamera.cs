
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
    
public float camSmoothSpeed = 0.1f;
public float camToPlayerRadius = 8.0f;
public float camHeightOffset = 5.0f;
//public float camManualRotation = 90.0f;

public Transform playerCam;
private float camHorizontal;

private bool isCamMoving = false;

void Start() {
    //playerCam = Camera.main.transform;
}
void Update() {
      camHorizontal = Input.GetAxis ("RightHorizontal");  
      isCamMoving = Mathf.Abs(camHorizontal)> 0.0f;
}
    
    void FixedUpdate() {
        playerCam.rotation = Quaternion.LookRotation(transform.position - playerCam.position, Vector3.up);
        playerCam.position = Vector3.Lerp(playerCam.position, GetCameraTargetPosition(), camSmoothSpeed);
    }

    private Vector3 GetCameraTargetPosition() {
        Vector3 camTargetPosition;
        camTargetPosition = playerCam.position + (GetCameraToPlayerDirection().normalized * (GetCameraToPlayerDirection().magnitude - camToPlayerRadius));
        camTargetPosition = new Vector3(camTargetPosition.x, transform.position.y + camHeightOffset, camTargetPosition.z);
        return camTargetPosition;
    }
    private Vector3 GetCameraToPlayerDirection() {
            Vector3 camToPlayerDirection;
            camToPlayerDirection = new Vector3(transform.position.x - playerCam.position.x, 0, transform.position.z - playerCam.position.z);
            return camToPlayerDirection;
    }
   
}
