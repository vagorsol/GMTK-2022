using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static int MAX_ROOMS = 1_000_000_000;
    private int roomId = 0;
    private float startTime = 0;
    private Dictionary<int, RoomDetail> visitedMap;
    private List<int> visitedList;
    
    public Text timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable() {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = (Time.time - startTime).ToString("0");
    }

    public int GetRoom()
    {
        return roomId;
    }

    public void SetRoom(int id)
    {
        roomId = Mathf.Clamp(id, 0, MAX_ROOMS);
        Debug.Log(roomId);
    }

    public void MoveRoom(int dir) {
        roomId = Mathf.Clamp(roomId + (int)Mathf.Sign(dir), 0, MAX_ROOMS - 1);
        Debug.Log(roomId);
    }

    public float GetTime() {
        return Time.time - startTime;
    }
}

struct RoomDetail {
    HashSet<int> collected;
}
