using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Croisant_Crawler.Core;
using Croisant_Crawler.UnityExtensions;

public class Hero : MonoBehaviour
{
    public PlayerStats stats;

    void Awake()
    {
        stats = new PlayerStats();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // bool isAnimating_Movement

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
            Move(Croisant_Crawler.Data.Vector2Int.Up);
        else if(Input.GetKeyDown(KeyCode.S))
            Move(Croisant_Crawler.Data.Vector2Int.Down);
        else if(Input.GetKeyDown(KeyCode.A))
            Move(Croisant_Crawler.Data.Vector2Int.Left);
        else if(Input.GetKeyDown(KeyCode.D))
            Move(Croisant_Crawler.Data.Vector2Int.Right);
    }

    public void Move(Croisant_Crawler.Data.Vector2Int dirrection)
    {
        // DEBUG:
        stats.TakeDamage(5);

        
        var nextPos = stats.position + dirrection;
        var newRoom = GameMaster.currentFloorData.rooms[stats.position].connections
                .Where(room => room.position == nextPos)
                .FirstOrDefault();
        if(newRoom is null)
            return;
        
        stats.position = newRoom.position;
        transform.position = GameMaster.currentFloor._grid.CellToLocal(stats.position.ToUnityVector3Int());

    }

    // public void Animate_Movement()
}
