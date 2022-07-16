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
    public Vector2 jumpHeight;
    private float moveAmount;
    private bool hasJumped = false;


    void Update(){
        // left/right movement
        moveAmount = Input.GetAxis("Horizontal");
        
        var x = moveAmount * Time.deltaTime * speed;

        // TODO: handling double jumps
        if((Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0)|| Input.GetButtonDown("Jump")){
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            hasJumped = true; 
        }

        gameObject.transform.Translate(x, 0, 0);
    }
}
