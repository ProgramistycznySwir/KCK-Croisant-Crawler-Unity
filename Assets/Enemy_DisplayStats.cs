using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Croisant_Crawler.Core;

public class Enemy_DisplayStats : MonoBehaviour
{
    public Enemy enemy;

    public TMPro.TextMeshPro hp_text;
    public SpriteRenderer hp_bar;
    public TMPro.TextMeshPro name_text;
    public TMPro.TextMeshPro damage_text;

    // Start is called before the first frame update
    void Start()
    {
        SubscribeToChanges();
        OnIsDeadChange(enemy.stats);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        UnsubscribeFromChanges();
    }

    void SubscribeToChanges()
    {
        enemy.stats.HP_OnChange += OnHPChange;
        enemy.stats.IsDead_OnChange += OnIsDeadChange;
        enemy.stats.Dmg_OnChange += OnDmgChange;
    }
    void UnsubscribeFromChanges()
    {
        enemy.stats.HP_OnChange -= OnHPChange;
        enemy.stats.IsDead_OnChange -= OnIsDeadChange;
        enemy.stats.Dmg_OnChange -= OnDmgChange;
    }

    public void OnHPChange(Stats stats)
    {
        hp_text.text = $"{stats.HP.value}/{stats.HP.range.max}";
        hp_bar.size = new Vector2(stats.HP.Percent, 1f);
    }
    public void OnIsDeadChange(Stats stats)
    {
        name_text.text = $"{stats.Name}{(stats.IsDead ? " (dead)" : "")}";
    }
    public void OnDmgChange(Stats stats)
    {
        damage_text.text = $"Dmg: {stats.DamageRange.min}-{stats.DamageRange.max}";
    }
}
