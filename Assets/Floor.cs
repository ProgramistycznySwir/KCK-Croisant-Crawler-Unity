using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Croisant_Crawler.Data;

public class Floor : MonoBehaviour
{
    Croisant_Crawler.Core.Floor floor;

    public UnityEngine.Vector2Int mapSize = new UnityEngine.Vector2Int(6, 6);
    public int roomCount = 24;

    public Room roomPrefab;

    public static Grid grid;
    public Grid _grid;

    // Start is called before the first frame update
    void Awake()
    {
        grid = _grid;

        floor = new(mapSize: (Croisant_Crawler.Data.Vector2Int)mapSize,
                level: 1,
                roomCount: roomCount);
        foreach(Croisant_Crawler.Core.Room room in floor.rooms.Values)
        {
            Object.Instantiate(roomPrefab).GetComponent<Room>().Init(room);
        }
        // floor
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
