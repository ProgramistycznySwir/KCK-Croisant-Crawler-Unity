using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        enemies = new List<Enemy>();

        for (int i = 0; i < fight.enemies.Count; i++)
            enemies.Add(Object.Instantiate(enemyPrefab, enemySockets[i])
                    .GetComponent<Enemy>()
                    .Init(fight.enemies[i]));
        
    }

    public void Hero_AttackEnemy(Enemy enemy)
    {
        int damage = hero.stats.GetDamage();
        enemy.stats.TakeDamage(damage);

        if(enemy.stats.IsDead)
        {
            hero.stats.ReceiveExp(PlayerStats.ExpGainFormula(hero.stats, enemy.stats));
        }
        if (fight.enemies.All(enemy => enemy.IsDead))
        {
            GameMaster.instance.EndFight(FightResult.Victory);
            return;
        }


        AllEnemies_AttackHero();
    }

    public void AllEnemies_AttackHero()
    {
        foreach(Stats enemy in fight.enemies)
        {
            if(enemy.IsDead)
                continue;
            int damage = enemy.GetDamage();
            int receivedDamage = hero.stats.TakeDamage(damage);
            // view.Log(DamageMessage($"[{selectedTargetIndex + 1}]{selectedTarget.Name}", hero.stats.Name, receivedDamage.ToString()));
            if(hero.stats.IsDead)
            {
                GameMaster.instance.EndFight(FightResult.TPK);
                return;
            }
        }
    }

    void CleanUp()
    {
        foreach (var socket in enemySockets)
            foreach (Transform child in socket)
                GameObject.Destroy(child.gameObject);
    }
}
