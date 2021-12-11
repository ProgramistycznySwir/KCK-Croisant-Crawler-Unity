using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Croisant_Crawler.Core;

public class PlayerStats_Display : MonoBehaviour
{
    public Hero hero;

    public TMPro.TextMeshProUGUI text_HP;

    // Start is called before the first frame update
    void Start()
    {
        hero.stats.HP_OnChange += UpdateHP;
    }

    public void UpdateHP(Stats stats)
    {
        text_HP.text = $"HP: {stats.HP}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
