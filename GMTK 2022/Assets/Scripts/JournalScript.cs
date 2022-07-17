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
        digits = new int[9];
        for (int i = 0; i < 9; i++) {
            digits[i] = -1;
        }
        
        control = new PlayerControl();
        control.Journal.JournalMenu.started += ShowMenu;
        control.Journal.JournalMenu.canceled += HideMenu;

        text.text = "*********";
        menuCanvas.enabled = false;
    }

    void OnDestroy() {
        control.Journal.JournalMenu.started -= ShowMenu;
        control.Journal.JournalMenu.canceled -= HideMenu;
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
        text.text.Remove(position, 1);
        text.text.Insert(position, digit.ToString("0"));
        Debug.Log(text.text);
    }

    void ShowMenu(InputAction.CallbackContext ctx) {
        menuCanvas.enabled = true;
    }

    void HideMenu(InputAction.CallbackContext ctx) {
        menuCanvas.enabled = false;
    }
}
