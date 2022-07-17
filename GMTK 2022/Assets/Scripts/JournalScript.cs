using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;

public class JournalScript : MonoBehaviour
{
    private int[] digits;
    private PlayerControl control;
    [SerializeField]
    private Canvas menuCanvas;
    [SerializeField]
    private Text text;

    void Awake() {
        digits = new int[6];
        for (int i = 0; i < 6; i++) {
            digits[i] = -1;
        }
        
        control = new PlayerControl();
        control.Journal.JournalMenu.started += ShowMenu;
        control.Journal.JournalMenu.canceled += HideMenu;

        text.text = "******";
        menuCanvas.enabled = false;
    }

    void OnDestroy() {
        control.Journal.JournalMenu.started -= ShowMenu;
        control.Journal.JournalMenu.canceled -= HideMenu;
    }

    void OnEnable() {
        control.Journal.Enable();
    }

    void OnDisable() {
        control.Journal.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void recordDigit(int digit, int position) {
        digits[position] = digit;
        string exit = text.text;
        Debug.Log(exit);
        exit = exit.Remove(position, 1).Insert(position, digit.ToString("0"));
        Debug.Log(exit);
        text.text = exit;
    }

    void ShowMenu(InputAction.CallbackContext ctx) {
        Debug.Log("showing menu");
        menuCanvas.enabled = true;
    }

    void HideMenu(InputAction.CallbackContext ctx) {
        menuCanvas.enabled = false;
    }
}
