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

    public Transform[] buttons;

    void Start()
    {
        hero.stats.HP_OnChange += UpdateHP;
        hero.stats.Agi_OnChange += UpdateAgi;
        hero.stats.Vit_OnChange += UpdateVit;
        hero.stats.Str_OnChange += UpdateStr;
        hero.stats.Exp_OnChange += UpdateExp;

        UpdateHP(hero.stats);
        UpdateAgi(hero.stats);
        UpdateVit(hero.stats);
        UpdateStr(hero.stats);
        UpdateExp(hero.stats);
        //TODO update statystyk przy zmianie widoku
    }
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
        UpdateSkillPoints();
    }
    public void UpdateVit(Stats stats)
    {
        text_VIT_stat.text = $"Vitality: {hero.stats.Vit}";
    }
    public void UpgradeVit()
    {
        hero.stats.UpgradeVit();
        UpdateSkillPoints();
    }

    public void UpdateStr(Stats stats)
    {
        text_STR_stat.text = $"Strength: {hero.stats.Str}";
    }
    public void UpgradeStr()
    {
        hero.stats.UpgradeStr();
        UpdateSkillPoints();
    }

    public void UpdateExp(Stats stats)
    {
        text_XP_stat.text = $"XP: {hero.stats.Exp} / {(PlayerStats.ExpPerLevel / 2) * hero.stats.Lvl * (hero.stats.Lvl - 1)}";
        text_LVL_stat.text = $"LVL: {stats.Lvl}";
        UpdateSkillPoints();
    }
    public void UpdateSkillPoints()
    {
        text_SkillPoint_stat.text = $"Skill Points left:    {hero.stats.SkillPoints}";
        // Disable or enable buttons.
        bool areThereSkillPoints = hero.stats.SkillPoints > 0;
        foreach(var button in buttons)
            button.gameObject.SetActive(areThereSkillPoints);
    }
}