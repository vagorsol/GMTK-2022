/**
    Created by: Audrey Yang

*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuing : MonoBehaviour {
    
    public void StartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit(){
        Debug.Log("Now Exiting the Game!");
        Application.Quit();
    }
}
