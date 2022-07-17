using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueScript : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp() {
        levelManager.CollectClue();
        gameObject.SetActive(false);
    }
}
