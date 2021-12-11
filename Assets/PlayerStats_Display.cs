using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Croisant_Crawler.Core;

public class PlayerStats_Display : MonoBehaviour
{
    public Hero hero;
    public Image healthBar;


    public TMPro.TextMeshProUGUI text_HP;
    void Start()
    {
        hero.stats.HP_OnChange += UpdateHP;

    }

    public void UpdateHP(Stats stats)
    {
        text_HP.text = $"HP: {stats.HP.value} / {stats.HP.range.max}";
        healthBar.fillAmount = stats.HP.Percent;

    }

    // Update is called once per frame
    void Update()
    {        

    }
}
