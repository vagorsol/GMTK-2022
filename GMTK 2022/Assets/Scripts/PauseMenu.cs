using UnityEngine.InputSystem;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    private bool isGamePaused = false;
    private PlayerControl control;
    [SerializeField]
    private GameObject pauseMenuUI;

    void Awake()
    {
        control = new PlayerControl();
        control.Menu.Pause.started += TogglePause;
    }

    void OnDestroy()
    {
        control.Menu.Pause.started -= TogglePause;
    }

    void OnEnable() {
        control.Enable();
    }

    void OnDisable() {
        control.Disable();
    }

    void Update()
    {

    }

    void TogglePause(InputAction.CallbackContext ctx)
    {
        TogglePause();
    }

    public void TogglePause()
    {
        Debug.Log("pause toggled");
        if(isGamePaused){
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            isGamePaused = false;
        } else {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            isGamePaused = true;
        }
    }
}