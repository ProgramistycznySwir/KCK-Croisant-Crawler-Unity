using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Croisant_Crawler.Core;

public class DisplayRunSummary : MonoBehaviour
{
    public Text text;

    void Start()
    {
        text.text = $"{RunSummary.ExploredRooms}\n{RunSummary.DefeatedEnemies}";
    }
}
