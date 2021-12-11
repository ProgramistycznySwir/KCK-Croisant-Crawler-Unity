﻿using System;
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
            Enemies = JsonUtility
                    .FromJson<List<Stats_Prototype>>(((TextAsset)Resources.Load(ResourceName)).text)
                    .ToDictionary(item => item.Name);
        }
            // => Enemies = JsonSerializer
            //         .Deserialize<List<Stats_Prototype>>(File.ReadAllText(Filename))
            //         .ToDictionary(item => item.Name);

        public static void DEBUG_CreateExampleFile()
        {
            List<Stats_Prototype> list = new();
            list.Add(new Stats_Prototype());
            list.Add(new Stats_Prototype());

            File.WriteAllText("Res/enemies_example.json", JsonUtility.ToJson(list));
        }
    }
}






