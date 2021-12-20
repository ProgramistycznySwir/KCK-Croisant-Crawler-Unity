using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;

public class PlayerStats_Display : MonoBehaviour
{
    public Hero hero;
    public Image healthBar;
    public Image expBar;


    public TMPro.TextMeshProUGUI text_HP;
    public TMPro.TextMeshProUGUI text_XP;
    void Start()
    {
        hero.stats.HP_OnChange += UpdateHP;
        hero.stats.Exp_OnChange += UpdateExp;
        UpdateHP(hero.stats);
        UpdateExp(hero.stats);
    }

    public void UpdateHP(Stats stats)
    {
        text_HP.text = $"HP: {stats.HP.value} / {stats.HP.range.max}";
        healthBar.fillAmount = stats.HP.Percent;
    }

    public void UpdateExp(PlayerStats stats)
    {
        expBar.fillAmount = new ValueInRangeInt(
                new Croisant_Crawler.Data.RangeInt(
                        PlayerStats.ExpFormula(stats.Lvl),
                        PlayerStats.ExpFormula(stats.Lvl+1)),
                stats.Exp)
                .Percent;
        text_XP.text = $"  Exp: {stats.Exp} / {PlayerStats.ExpFormula(stats.Lvl+1)}";
    }
}
