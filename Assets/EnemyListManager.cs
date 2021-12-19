using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Croisant_Crawler.Core;

/// <summary>
/// The only thing this object does is load EnemyList
/// </summary>
public class EnemyListManager : MonoBehaviour
{
    void Awake()
    {
        EnemyList.LoadFromJson();
        Debug.Log($"Loaded enemies from: {EnemyList.ResourceName}.json");
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
