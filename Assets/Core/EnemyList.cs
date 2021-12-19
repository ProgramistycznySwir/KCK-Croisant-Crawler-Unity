using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
// using System.Text.Json;
using System.IO;

namespace Croisant_Crawler.Core
{
    public static class EnemyList
    {
        public const string ResourceName = "enemies";

        public static Dictionary<string, Stats_Prototype> Enemies { get; set; }
        public static int EnemyCount => Enemies.Count;
        // public string name { get; set; }

        public static Stats GenerateEnemy(int index, int level)
            => Enemies.Values.Skip(index).First().GenerateStats(level);
        public static Stats GenerateEnemy(string name, int level)
            => Enemies[name].GenerateStats(level);

        public static void LoadFromJson()
        {
            TextAsset jasonFile = (TextAsset)Resources.Load(ResourceName);
            var enemyData = JsonUtility.FromJson<EnemyData>(jasonFile.text);
            var enemyList = enemyData.EnemyList;
            Enemies = enemyList.ToDictionary(item => item.Name);
            // Enemies = JsonUtility
            //         .FromJson<EnemyData>(jasonFile.text)
            //         .EnemyList
            //         .ToDictionary(item => item.Name);
        }
            // => Enemies = JsonSerializer
            //         .Deserialize<List<Stats_Prototype>>(File.ReadAllText(Filename))
            //         .ToDictionary(item => item.Name);

        public static void DEBUG_CreateExampleFile()
        {
            EnemyData enemyData = new();
            // List<Stats_Prototype> list = new();
            enemyData.EnemyList = new Stats_Prototype[4];
            enemyData.EnemyList[0] = new Stats_Prototype();
            enemyData.EnemyList[1] = new Stats_Prototype();

            File.WriteAllText("enemies_example.json", JsonUtility.ToJson(enemyData, true));
        }
    }
}






