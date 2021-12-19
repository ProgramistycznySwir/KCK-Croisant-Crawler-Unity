using System;
using System.Collections.Generic;

/// <summary>
/// Data class needed for Unity to read json
/// </summary>
namespace Croisant_Crawler.Core
{
    [Serializable]
    public class EnemyData
    {
        public Stats_Prototype[] EnemyList;
    }
}