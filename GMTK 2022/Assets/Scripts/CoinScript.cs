using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;
    public int id { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        id = levelManager.AddCoin(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp()
    {
        levelManager.CollectCoin(id);
        Debug.LogFormat("picked up coin {0}", id);
        gameObject.SetActive(false);
    }
}
