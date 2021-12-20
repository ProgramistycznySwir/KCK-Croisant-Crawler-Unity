using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Croisant_Crawler.Core;

public class Enemy : MonoBehaviour
{
    public Stats stats { get; private set; }

    public SpriteRenderer renderer;
    public Collider2D collider;

    public Sprite[] enemySprites;
    public Sprite square;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        UnsubscribeFromChanges();
    }

    public Enemy Init(Stats stats)
    {
        this.stats = stats;
        renderer.sprite = GetEnemySprite(stats.Name);

        SubscribeToChanges();

        return this;
    }

    void SubscribeToChanges()
    {
        this.stats.IsDead_OnChange += Die;
    }
    void UnsubscribeFromChanges()
    {
        this.stats.IsDead_OnChange -= Die;
    }

    public Sprite GetEnemySprite(string name)
        => name switch {
            "Goblin" => enemySprites[0],
            "Bandit" => enemySprites[2],
            "Skeleton" => enemySprites[3],
            _ => square
        };
    public void GetAttacked()
    {
        FightManager.instance.Hero_AttackEnemy(this);
    }

    public void Die(Stats stats)
    {
        renderer.color = Color.gray;
        collider.enabled = false;
    }
}
