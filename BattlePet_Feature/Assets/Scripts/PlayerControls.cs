using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Jackson, Katherine
//12/05/23
//Defines a list of functions meant to move and navigate the player around the scene.

public class PlayerControls : MonoBehaviour
{

    PlayerInputActions playerActions;

    private void Awake()
    {
        playerActions = new PlayerInputActions(); //Constructor
        //Enable the Input class
        playerActions.Enable();
    }

    private void FixedUpdate()
    {
        //gets the Vector 2 data from the Move Action Composite
        Vector2 moveVec = playerActions.PlayerInGameActions.Move.ReadValue<Vector2>();
        //Apply the move vector to the player
        GetComponent<Rigidbody>().AddForce(new Vector3(moveVec.x, 0, moveVec.y) * 5f, ForceMode.Force);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump! : " + context.phase);
        if(context.performed)
        {
            Debug.Log("Real Jump");
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveVec = context.ReadValue<Vector2>();
        GetComponent<Rigidbody>().AddForce(new Vector3(moveVec.x, 0, moveVec.y) * 5f, ForceMode.Force);
    }
}
