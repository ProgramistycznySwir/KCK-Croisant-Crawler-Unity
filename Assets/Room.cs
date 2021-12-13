using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Croisant_Crawler.Data;
using Croisant_Crawler.UnityExtensions;

public class Room : MonoBehaviour
{
    public SpriteRenderer renderer;
    public Sprite[] spriteSheet;

    public Croisant_Crawler.Core.Room room;
    public Connections connections;

    public Room Init(Croisant_Crawler.Core.Room room)
    {
        this.room = room;
        transform.localPosition = Floor.grid.CellToLocal(room.position.ToUnityVector3Int());

        foreach(Croisant_Crawler.Core.Room connection in room.connections)
        {
            Croisant_Crawler.Data.Vector2Int relativePosition = room.position - connection.position;
            if(relativePosition == Croisant_Crawler.Data.Vector2Int.Up)
                connections += Connections.Down;
            if(relativePosition == Croisant_Crawler.Data.Vector2Int.Right)
                connections += Connections.Left;
            if(relativePosition == Croisant_Crawler.Data.Vector2Int.Down)
                connections += Connections.Up;
            if(relativePosition == Croisant_Crawler.Data.Vector2Int.Left)
                connections += Connections.Right;
        }
        renderer.sprite = GetSprite(connections);

        return this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal Sprite GetSprite(Croisant_Crawler.Data.Connections connections)
    {
        return connections.data switch {
            0b1111 => spriteSheet[0],
            0b0000 => spriteSheet[1],
            0b0101 => spriteSheet[2],
            0b1010 => spriteSheet[3],
            0b0001 => spriteSheet[4],
            0b0010 => spriteSheet[5],
            0b0100 => spriteSheet[6],
            0b1000 => spriteSheet[7],
            0b0011 => spriteSheet[8],
            0b0110 => spriteSheet[9],
            0b1100 => spriteSheet[10],
            0b1001 => spriteSheet[11],
            0b0111 => spriteSheet[12],
            0b1110 => spriteSheet[13],
            0b1101 => spriteSheet[14],
            0b1011 => spriteSheet[15],
            _ => spriteSheet[0]
        };
    }

    public Room Explore()
    {
        if(room.IsExplored is true)
            return this;
        // Show room:
        gameObject.SetActive(true);
        room.IsExplored = true;

        if(room.IsDangerous)
        {
            GameMaster.StartFight();

            // Map_View.DisplayPrompt("You've encountered enemies in this room, press [enter] to start combat.");
            // Map_View.AlertPlayer(player, "[ENTER]");
            // Wait();

            // Map_View.SetActive(false);
            // FightResult fightResult = Fight_Game.StartFight(player, newRoom);
            // if(fightResult is FightResult.TPK)
            // {
            //     Summary(player);
            //     return;
            // }
            // newRoom.IsDangerous = false;
            // Map_View.ReRenderMapView(floor, player);
        }

        return this;
    }
}
