using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Croisant_Crawler.Core;
using Croisant_Crawler.UnityExtensions;

public class Hero_Map : MonoBehaviour
{
    public Hero hero;

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
        hero.stats.ReceiveExp(500);


        var nextPos = hero.stats.position + dirrection;
        var newRoomData = GameMaster.currentFloorData.rooms[hero.stats.position].connections
                .Where(room => room.position == nextPos)
                .FirstOrDefault();
        if(newRoomData is null)
            return;
        
        var newRoom = GameMaster.currentFloor.rooms[newRoomData.position];
        newRoom.Explore();
        
        hero.stats.position = newRoomData.position;
        transform.position = GameMaster.currentFloor._grid.CellToLocal(hero.stats.position.ToUnityVector3Int());
    }

    // public void Animate_Movement()
}
