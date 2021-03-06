using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Croisant_Crawler.UnityExtensions;

public class GameMaster : MonoBehaviour
{
    /// Singleton.
    public static GameMaster instance { get; private set; }
    public GameMaster() => instance = this;

    public Hero hero;
    public Hero_Map hero_map;

    public static Croisant_Crawler.Core.Floor currentFloorData { get; private set; }
    public static Floor currentFloor { get; private set; }

    public Floor floorPrefab;

    public UnityEngine.Vector2Int mapSize = new UnityEngine.Vector2Int(6, 6);
    public int roomCount = 24;

    void Start()
    {
        Croisant_Crawler.Core.RunSummary.Reset();
        currentFloorData = new(
                mapSize: mapSize.ToData(),
                level: 1,
                roomCount: roomCount);

        currentFloor = UnityEngine.Object.Instantiate(floorPrefab, ViewManager.instance.views[ViewManager.View.Map])
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

    public void StartFight(Croisant_Crawler.Core.Room room)
    {
        ViewManager.instance.View_Open(ViewManager.View.Fight);
        FightManager.instance.StartFight(room.distanceFromStart);
        // mapView.gameObject.SetActive(false);
        // fightView.gameObject.SetActive(true);
    }

    public void EndFight(FightManager.FightResult fightResult)
    {
        if(fightResult is FightManager.FightResult.Victory)
            ViewManager.instance.View_Open(ViewManager.View.Map);
        else if(fightResult is FightManager.FightResult.TPK)
            SceneManager.LoadScene("GameOver");
        // mapView.gameObject.SetActive(true);
        // fightView.gameObject.SetActive(false);
    }
}
