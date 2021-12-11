using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Croisant_Crawler.UnityExtensions;

public class GameMaster : MonoBehaviour
{
    public Hero hero;

    public static Croisant_Crawler.Core.Floor currentFloorData { get; private set; }
    public static Floor currentFloor { get; private set; }

    public Floor floorPrefab;

    public UnityEngine.Vector2Int mapSize = new UnityEngine.Vector2Int(6, 6);
    public int roomCount = 24;

    void Awake()
    {
        currentFloorData = new(
                mapSize: mapSize.ToData(),
                level: 1,
                roomCount: roomCount);

        currentFloor = Object.Instantiate(floorPrefab)
                .GetComponent<Floor>()
                .Init(currentFloorData);

        hero.transform.position = currentFloor._grid.CellToLocal(currentFloorData.startRoomPos.ToUnityVector3Int());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
