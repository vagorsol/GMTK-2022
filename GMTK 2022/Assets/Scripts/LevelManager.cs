using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static int MAX_ROOMS = 900_000_000;
    private int roomId = 0;
    private float startTime = 0;
    private int exitRoom;
    private Dictionary<int, RoomDetail> visitedMap;
    private List<int> visitHistory;
    private RoomDetail currentRoomDetail;
    private List<CoinScript> coins;
    private bool[] collectedClues;
    [SerializeField]
    private ClueScript clue;
    private List<TerrainScript> dynTerrain;
    [SerializeField]
    private Text timer;
    [SerializeField]
    private Text roomNumber;

    void Awake() {
        visitHistory = new List<int>();
        visitedMap = new Dictionary<int, RoomDetail>();
        AddRoomToHistory(roomId);
        coins = new List<CoinScript>();
        dynTerrain = new List<TerrainScript>();
        collectedClues = new bool[9];
        
        exitRoom = Random.Range(0, MAX_ROOMS);
    }

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
        roomNumber.text = roomId.ToString("Room 000 000 000");
        AddRoomToHistory(roomId);
        BuildRoom(roomId);
        Debug.Log(roomId);
    }

    public void MoveRoom(int dir) {
        roomId = Mathf.Clamp(roomId + (int)Mathf.Sign(dir), 0, MAX_ROOMS - 1);
        roomNumber.text = roomId.ToString("000 000 000");
        AddRoomToHistory(roomId);
        BuildRoom(roomId);
        Debug.Log(roomId);
    }

    void AddRoomToHistory(int roomId) {
        visitHistory.Add(roomId);
        if (!visitedMap.TryGetValue(roomId, out currentRoomDetail)) {
            currentRoomDetail = new RoomDetail();
            visitedMap.Add(roomId, currentRoomDetail);
        }
    }

    void BuildRoom(int roomId) {
        int position = 0;
        foreach (CoinScript coin in coins) {
            if (!currentRoomDetail.collected.Contains(coin.id)) {
                coin.gameObject.SetActive((roomId >> position & 1) == 0);
            }
            position = (position + 1) % 30;
        }
        if (!collectedClues[GetFloor()]) {
            clue.gameObject.SetActive((roomId >> position & 1) == 0);
        }
        position = (position + 1) % 30;
        foreach (TerrainScript te in dynTerrain) {
            te.gameObject.SetActive((roomId >> position & 1) == 0);
            position = (position + 1) % 30;
        }
    }

    public float GetTime() {
        return Time.time - startTime;
    }

    public int AddCoin(CoinScript cs) {
        coins.Add(cs);
        return coins.Count - 1;
    }

    public void CollectCoin(int id) {
        currentRoomDetail.collected.Add(id);
    }

    public void CollectClue() {
        Debug.LogFormat("collected floor {0} clue", GetFloor());
        collectedClues[GetFloor()] = true;
    }

    public int AddTerrain(TerrainScript ts) {
        dynTerrain.Add(ts);
        return dynTerrain.Count;
    }

    public int GetFloor() {
        return roomId / 100_000_000;
    }

    public int GetExitRoomDigit() {
        return (exitRoom / (int) Mathf.Pow(10, 8 - GetFloor())) % 10;
    }
}

class RoomDetail {
    public HashSet<int> collected;

    public RoomDetail() {
        collected = new HashSet<int>();
    }
}
