using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineScript : MonoBehaviour
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

    public int GenerateKey() {
        int time = (int)levelManager.GetTime();
        int room = levelManager.GetRoom();
        int key = 0;
        Debug.LogFormat("Time: {0}, Room: {1}", time, room);
        for (int i = 0; i < 3; i++) {
            int n = 8 - 3 * i - time % 10 % 3;
            key += (int) Mathf.Pow(10, 2 - i) * ((room / (int) Mathf.Pow(10, n)) % 10);
        }
        Debug.Log("Generated key: " + key.ToString());
        return key;
    }
}
