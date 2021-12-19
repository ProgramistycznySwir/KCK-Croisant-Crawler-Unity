using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Croisant_Crawler.Core;

public class FightManager : MonoBehaviour
{
    /// Singleton.
    public static FightManager instance { get; private set; }
    public FightManager() => instance = this;

    public Fight fight { get; private set; }
    public Hero hero;

    public GameObject enemyPrefab;
    public Transform[] enemySockets;
    public List<Enemy> enemies;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFight(int distanceFromStart)
    {
        fight = new Fight(distanceFromStart);

        for (int i = 0; i < fight.enemies.Count; i++)
            enemies.Add(Object.Instantiate(enemyPrefab, enemySockets[i])
                    .GetComponent<Enemy>()
                    .Init(fight.enemies[i]));
        
    }
}
