using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Croisant_Crawler.Core;

public class PlayerStats_Menu : MonoBehaviour
{

    public Hero hero;
    public TMPro.TextMeshProUGUI text_HP_stat;
    public TMPro.TextMeshProUGUI text_XP_stat;
    public TMPro.TextMeshProUGUI text_LVL_stat;
    public TMPro.TextMeshProUGUI text_AGI_stat;
    public TMPro.TextMeshProUGUI text_VIT_stat;
    public TMPro.TextMeshProUGUI text_STR_stat;
    public TMPro.TextMeshProUGUI text_SkillPoint_stat;

    void Start()
    {
        hero.stats.HP_OnChange += UpdateHP;
        hero.stats.Agi_OnChange += UpdateAgi;
        hero.stats.Vit_OnChange += UpdateVit;
        hero.stats.Str_OnChange += UpdateStr;
        UpdateHP(hero.stats);
        UpdateAgi(hero.stats);
        UpdateVit(hero.stats);
        UpdateStr(hero.stats);
        //TODO update statystyk przy zmianie widoku
        text_XP_stat.text = $"XP: {hero.stats.Exp} / {(PlayerStats.ExpPerLevel / 2) * hero.stats.Lvl * (hero.stats.Lvl - 1)}";
        text_LVL_stat.text = $"LVL: {hero.stats.Lvl}";
        text_SkillPoint_stat.text = $"Skill Points left:    {hero.stats.SkillPoints}";
    }
      
       // TODO: update statystyk
    public void UpdateHP(Stats stats)
    {
        text_HP_stat.text = $"HP: {stats.HP.value} / {stats.HP.range.max}";
    }
    public void UpdateAgi(Stats stats)
    {
        text_AGI_stat.text = $"Agility: {stats.Agi}";
    }
    public void UpgradeAgi()
    {
        hero.stats.UpgradeAgi();
    }
        public void UpdateVit(Stats stats)
    {
        text_VIT_stat.text = $"Vitality: {hero.stats.Vit}";
    }
    public void UpgradeVit()
    {
        hero.stats.UpgradeVit();
    }

    public void UpdateStr(Stats stats)
    {
        text_STR_stat.text = $"Strength: {hero.stats.Str}";
    }
    public void UpgradeStr()
    {
        hero.stats.UpgradeStr();
    }
}