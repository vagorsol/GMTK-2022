/**
    Author: Audrey Yang
    Date Created: 7/15/2022
    Date Modified: N/A
    Player movement and interaction controls
*/

using UnityEngine;

public class PlayerControls : MonoBehaviour{

    public float speed = 6.0f;
    private float moveAmount;

    void Update() {
        // left/right movement
        moveAmount = Input.GetAxis("Horizontal");
        gameObject.transform.position = new Vector2(transform.position.x + (moveAmount * speed), transform.position.y);

        // click to interact with objects?
        if(Input.GetButton("Fire1")){

        }
    }
}
