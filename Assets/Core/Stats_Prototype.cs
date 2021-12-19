using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Croisant_Crawler.Core
{
    /// Added System.SerializableAttribute
    ///  and changed every property of this class to field cause otherwise Unity does not recognize them in JsonSerialization :)
    ///  This smile at the end is smile of someone devoid of emotion at the end of 2 hours-long debugging session.
    [System.Serializable]
    public class Stats_Prototype
    {
        //public int Level { get; set; }
        public string Name;

        public float Base_Vit;
        public float Level_Vit;

        public float Base_Str;
        public float Level_Str;

        public float Base_Agi;
        public float Level_Agi;

        public float Base_Def;
        public float Level_Def;

        public float Base_Arm;
        public float Level_Arm;

        public Stats GenerateStats(int level)
            => new Stats(name: Name,
                    vit: (int)(Base_Vit + Level_Vit * level),
                    str: (int)(Base_Str + Level_Str * level),
                    agi: (int)(Base_Agi + Level_Agi * level),
                    def: (int)(Base_Def + Level_Def * level),
                    arm: (int)(Base_Arm + Level_Arm * level),
                    lvl: level
                    );
    }
}
