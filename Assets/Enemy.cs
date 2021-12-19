using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Croisant_Crawler.Core;

public class Enemy : MonoBehaviour
{
    public Stats stats { get; private set; }

    public SpriteRenderer renderer;

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

    public Enemy Init(Stats stats)
    {
        this.stats = stats;
        renderer.sprite = GetEnemySprite(stats.Name);

        return this;
    }

    public Sprite GetEnemySprite(string name)
        => name switch {
            "Skeleton" => enemySprites[3],
            _ => square
        };
}
