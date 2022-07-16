using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;

public class PhaserScript : MonoBehaviour
{
    private static float PHASE_COOLDOWN = 0.5f;
    [SerializeField]
    private LevelManager levelManager;
    [SerializeField]
    private Canvas menuCanvas;
    [SerializeField]
    private Image keyContent;
    [SerializeField]
    private GameObject keyTemplate;
    private PlayerControl control;
    private List<int> keyList;
    private int[] keys;
    private float phaseTime = 0;

    void Awake()
    {
        control = new PlayerControl();
        control.Phaser.PhaseUp.performed += PhaseUp;
        control.Phaser.PhaseDown.performed += PhaseDown;
        control.Phaser.PhaseMenu.started += ShowMenu;
        control.Phaser.PhaseMenu.canceled += HideMenu;

        keyList = new List<int>();
        keys = new int[] {-1, -1, -1};
    }

    void OnDestroy()
    {
        control.Phaser.PhaseUp.performed -= PhaseUp;
        control.Phaser.PhaseDown.performed -= PhaseDown;
        control.Phaser.PhaseMenu.started -= ShowMenu;
        control.Phaser.PhaseMenu.canceled -= HideMenu;
    }

    // Start is called before the first frame update
    void Start()
    {
        menuCanvas.enabled = false;
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

    public void AddKey(int key) {
        keyList.Add(key);
        GameObject keyObj = Instantiate(keyTemplate) as GameObject;
        KeyScript keyScript = keyObj.GetComponent<KeyScript>();
        keyScript.SetText(key.ToString());
        keyScript.SetCanvas(menuCanvas);
        keyObj.SetActive(true);
        keyObj.transform.SetParent(keyContent.transform, false);
        Debug.Log("Added key: " + key.ToString());
    }

    public void SetKey(int key, int position) {
        keys[position] = key;
    }

    void ShowMenu(InputAction.CallbackContext ctx) {
        menuCanvas.enabled = true;
    }

    void HideMenu(InputAction.CallbackContext ctx) {
        menuCanvas.enabled = false;
    }
    
    void PhaseUp(InputAction.CallbackContext ctx) {
        Debug.Log("phasing up");
        if (Time.time - phaseTime > PHASE_COOLDOWN) {
            levelManager.MoveRoom(1);
        }
        phaseTime = Time.time;
    }

    void PhaseDown(InputAction.CallbackContext ctx) {
        if (Time.time - phaseTime > PHASE_COOLDOWN) {
            levelManager.MoveRoom(-1);
        }
        phaseTime = Time.time;
    }

    public void Phase() {
        if (Time.time - phaseTime > PHASE_COOLDOWN) {
            int dest = 0;
            int power = 6;
            foreach (int key in keys) {
                int destSub = key < 1 ? Random.Range(0, 1000) : key;
                dest += destSub * (int)Mathf.Pow(10, power);
                power -= 3;
            }
            levelManager.SetRoom(dest);
        }
        phaseTime = Time.time;
    }
}
