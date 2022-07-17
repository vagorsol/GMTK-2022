using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool isGamePaused = false; 
    public GameObject pauseMenuUI;

    // TODO: known issue, Unity not detecting escape key being pressed
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("Escape key was pressed");
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
}