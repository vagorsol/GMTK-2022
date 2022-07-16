/**
    Author: Audrey Yang
    Date Created: 7/15/2022
    Date Modified: N/A
    Player movement and interaction controls:
        Move Left/Right: A/D  or left/right
        Change Level(?): W/D or up/down
        Jump: space
        Interact: F
        Open Inventory: E
        Pause?
*/

using UnityEngine;

public class PlayerControls : MonoBehaviour{

    public float speed = 6.0f;
    private float moveAmount;

    void Update() {
        // left/right movement
        moveAmount = Input.GetAxis("Horizontal");
        gameObject.transform.position = new Vector2(transform.position.x + (moveAmount * speed), transform.position.y);
        
        if(Input.GetButtonDown("Vertical")){

        }
        
        // open men
    }
}
