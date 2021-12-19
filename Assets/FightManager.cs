using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Croisant_Crawler.Core;

public class FightManager : MonoBehaviour
{
    /// Singleton.
    public static FightManager instance { get; private set; }
    public FightManager() => instance = this;

    public enum FightResult { Victory, TPK }

    public Fight fight { get; private set; }
    public Hero hero;

    public GameObject enemyPrefab;
    public Transform[] enemySockets;
    public List<Enemy> enemies;


    public void StartFight(int distanceFromStart)
    {
        fight = new Fight(distanceFromStart);

        for (int i = 0; i < fight.enemies.Count; i++)
            enemies.Add(Object.Instantiate(enemyPrefab, enemySockets[i])
                    .GetComponent<Enemy>()
                    .Init(fight.enemies[i]));
        
    }

    public void OnAttackEnemy(int index)
    {
        Debug.Log(index);
    }
}
