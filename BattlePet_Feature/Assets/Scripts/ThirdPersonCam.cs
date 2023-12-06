using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jackson, Katherine
//12/05/23
//A camera script for rotating the camera as well as player position simultaneously.

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")] //Header is used so
    public Transform orientation;
    public Transform player;
    public Transform playerObject;
    public Rigidbody rb;

    public float rotationSpeed;

    private void Start()
    {
        //So the cursor doesn't move off screen and is not visible to the player.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //rotate player orientation
        Vector3 viewDir = transform.position - new Vector3(transform.position.x, transform.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        //rotate the player object
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(inputDir != Vector3.zero)
            playerObject.forward = Vector3.Slerp(playerObject.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    }
}
