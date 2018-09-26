using System;
using System.Collections.Generic;
using ColorManagement;
using UnityEngine;

namespace Agents
{
    [System.Serializable]
    public class Faction
    {
        public string Name;
        public int Uid;
        public Color FactionColor;
        
        public Faction(int uid, string name)
        {
            this.Uid = uid;
            this.Name = name;
            this.FactionColor = ColorManager.NextColor();
        }
    }
    
    // faction factory singleton
    [System.Serializable]
    public class FactionManagerControl
    {
        private static readonly FactionManagerControl FactionManagerInstance = new FactionManagerControl();
        
        private readonly List<Faction> _factions;
        
        private FactionManagerControl()
        {
            this._factions = new List<Faction>();
        }

        public static Faction AddNewFaction(string name)
        {
            // do faction initialization stuff here
            Faction newFaction = new Faction(GetNumFactions(), name);
            
            // register faction
            RegisterNewFaction(newFaction);

            return newFaction;
        }
        
        public static Faction GetFactionWithId(int uid)
        {
            // get faction if it exists
            Faction faction;
            if (FactionManagerInstance != null && uid < GetNumFactions())
            {
                faction = FactionManagerInstance._factions[uid];
            }
            else
            {
                faction = null;
            }
            
            return faction;
        }
    
        public static int GetNumFactions()
        {
            return FactionManagerInstance._factions.Count;
        }

        private static void RegisterNewFaction(Faction faction)
        {
            // do any necessary processing on factions here; ex: faction relations, etc.
            FactionManagerInstance._factions.Add(faction);
        }

        public static List<Faction> GetFactions()
        {
            return FactionManagerInstance._factions;
        }
    }
}
