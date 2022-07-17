using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScript : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;
    public int id { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        id = levelManager.AddTerrain(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
