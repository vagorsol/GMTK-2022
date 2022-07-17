using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour
{
    private static float SCREEN_DURATION = 7;
    private static float FADE_OUT_DURATION = 1;

    [SerializeField]
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Fade", SCREEN_DURATION - FADE_OUT_DURATION);
        Invoke("NextScene", SCREEN_DURATION);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fade()
    {
        anim.SetTrigger("FadeTrigger");
    }

    void NextScene()
    {
        int idx = gameObject.scene.buildIndex;
        SceneManager.LoadScene((idx + 1) % SceneManager.sceneCountInBuildSettings);
    }
}
