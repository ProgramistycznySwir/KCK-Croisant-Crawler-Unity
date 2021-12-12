using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Croisant_Crawler.Data;

public class Floor : MonoBehaviour
{
    Croisant_Crawler.Core.Floor floor;

    public Room roomPrefab;
    public Dictionary<Croisant_Crawler.Data.Vector2Int, Room> rooms = new();

    public static Grid grid;
    public Grid _grid;

    public Floor Init(Croisant_Crawler.Core.Floor floor)
    {
        this.floor = floor;

        foreach(Croisant_Crawler.Core.Room room in floor.rooms.Values)
        {
            rooms.Add(
                    room.position,
                    Object.Instantiate(roomPrefab, transform)
                            .GetComponent<Room>()
                            .Init(room));
        }

        // Method chain pattern.
        return this;
    }

    // Start is called before the first frame update
    void Awake()
    {
        grid = _grid;
        // floor
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
