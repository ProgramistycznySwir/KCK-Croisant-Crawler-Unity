using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Croisant_Crawler.Core;

// Pure wrapper for PlayerStats class.
public class Hero : MonoBehaviour
{
    public PlayerStats stats { get; private set; }

    void Awake()
    {
        stats = new PlayerStats();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
