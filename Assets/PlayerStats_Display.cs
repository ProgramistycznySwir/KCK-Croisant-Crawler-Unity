using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Croisant_Crawler.Core;

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

    }

    public void UpdateHP(Stats stats)
    {
        text_HP.text = $"HP: {stats.HP.value} / {stats.HP.range.max}";
        healthBar.fillAmount = stats.HP.Percent;
        //TODO currently XP just a mockup, need to make it properly count XP
        expBar.fillAmount  = hero.stats.Exp / (PlayerStats.ExpPerLevel / 2) * hero.stats.Lvl * (hero.stats.Lvl - 1);
        text_XP.text = $"XP: {hero.stats.Exp} / {(PlayerStats.ExpPerLevel / 2) * hero.stats.Lvl * (hero.stats.Lvl - 1)}";

    }

}
