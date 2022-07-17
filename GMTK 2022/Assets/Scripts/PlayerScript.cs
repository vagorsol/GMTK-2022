using System;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // settings
    private float playerSpeed = 12.0f;
    private float jumpSpeed = 6.0f;

    // variables referenced from other parts of the game
    [SerializeField]
    private LevelManager levelManager;
    [SerializeField]
    private JournalScript journal;
    [SerializeField]
    private PhaserScript phaser;
    [SerializeField]
    private Text coins;
    [SerializeField]
    private Text winMessage;
    [SerializeField]
    private Canvas hints;
    [SerializeField]
    private Animator levelAnim;
    private Rigidbody2D rb;
    private PlayerControl control;

    // variables used by code
    private int collisionCount = 0;
    private int coinCount = 3;
    private bool grounded = true;
    private SpriteRenderer render;
    private SlotMachineScript slotMachine = null;
    private IDisposable hintEvent;
    private Animator playerAnim;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        control = new PlayerControl();
        control.Player.Jump.started += Jump;
        control.Player.PullSlotMachine.started += PullSlotMachine;
        control.Player.PullSlotMachine.started += HideHintsSlotMachine;
    }

    // Start is called before the first frame update
    void Start()
    {
        winMessage.enabled = false;
    }

    void OnDestroy() {
        control.Player.Jump.started -= Jump;
        control.Player.PullSlotMachine.started -= PullSlotMachine;
    }

    void OnEnable() {
        control.Enable();
    }

    void OnDisable() {
        control.Disable();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
        float xAxis = control.Player.Move.ReadValue<Vector2>().x;
        rb.velocity = new Vector2(playerSpeed * xAxis, rb.velocity.y);
        playerAnim.SetTrigger(xAxis != 0 ? "Movement" : "Stop");
        if (xAxis != 0) {
            render.flipX = xAxis < 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        collisionCount++;
        foreach (ContactPoint2D contact in collision.contacts) {
            if (contact.normal.y > 0.7f) {
                grounded = true;
            }
            break;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        collisionCount--;
        if (collisionCount == 0) {
            grounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        switch (collider.tag) {
            case "SlotMachine":
                slotMachine = collider.gameObject.GetComponent<SlotMachineScript>();
                break;
            case "Coin":
                coinCount++;
                coins.text = coinCount.ToString("0 coins");
                collider.gameObject.GetComponent<CoinScript>().PickUp();
                HideHints();
                break;
            case "Clue":
                collider.gameObject.GetComponent<ClueScript>().PickUp();
                journal.recordDigit(levelManager.GetExitRoomDigit(), levelManager.GetFloor());
                collider.gameObject.SetActive(false);
                HideHints();
                break;
            case "Milk":
                winMessage.enabled = true;
                collider.gameObject.SetActive(false);
                levelAnim.SetTrigger("FadeTrigger");
                Invoke("NextScene", 1);
                break;
        }
    }

    void HideHintsSlotMachine(InputAction.CallbackContext ctx) {
        control.Player.PullSlotMachine.started -= HideHintsSlotMachine;
        hints.enabled = false;
    }

    void HideHints() {
        hints.enabled = false;
    }

    void NextScene() {
        SceneManager.LoadScene(gameObject.scene.buildIndex + 1);
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.CompareTag("SlotMachine")) {
            slotMachine = null;
        }
    }

    void Jump(InputAction.CallbackContext ctx) {
        if (grounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            grounded = false;
        }
    }

    void PullSlotMachine(InputAction.CallbackContext ctx) {
        if (slotMachine != null && coinCount > 0) {
            coinCount--;
            coins.text = coinCount.ToString("0 coins");
            phaser.AddKey(slotMachine.GenerateKey());
        }
    }
}
