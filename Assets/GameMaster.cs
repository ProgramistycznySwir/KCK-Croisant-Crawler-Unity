using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Croisant_Crawler.UnityExtensions;

public class GameMaster : MonoBehaviour
{
    public Hero hero;
    public Hero_Map hero_map;

    public Transform mapView__;
    public static Transform mapView { get; private set; }
    public Transform fightView__;
    public static Transform fightView { get; private set; }

    public static Croisant_Crawler.Core.Floor currentFloorData { get; private set; }
    public static Floor currentFloor { get; private set; }

    public Floor floorPrefab;

    public UnityEngine.Vector2Int mapSize = new UnityEngine.Vector2Int(6, 6);
    public int roomCount = 24;

    void Awake()
    {
        mapView = mapView__;
        fightView = fightView__;
    }

    void Start()
    {
        currentFloorData = new(
                mapSize: mapSize.ToData(),
                level: 1,
                roomCount: roomCount);

        currentFloor = Object.Instantiate(floorPrefab, mapView)
                .GetComponent<Floor>()
                .Init(currentFloorData);

        var startRoom = currentFloor.rooms[currentFloorData.startRoomPos];
        startRoom.Explore();
        hero.stats.position = startRoom.room.position;
        hero_map.transform.position = currentFloor._grid.CellToLocal(hero.stats.position.ToUnityVector3Int());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void StartFight()
    {
        mapView.gameObject.SetActive(false);
        fightView.gameObject.SetActive(true);
    }

    public static void EndFight()
    {
        mapView.gameObject.SetActive(true);
        fightView.gameObject.SetActive(false);
    }
}
