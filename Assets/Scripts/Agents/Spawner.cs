using System.Collections;
using System.Collections.Generic;
using Agents;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Faction faction;
    public int NumSpawns;
    public float SpawnPeriod;
    
    public GameObject SpawnObject;
    public GameObject SpawnParent;
    
    private float TimeAtLastSpawn;
    
    // Use this for initialization
    void Start ()
    {
        TimeAtLastSpawn = Time.time - SpawnPeriod;
    }

    void Spawn()
    {
        for (int i = 0; i < NumSpawns; i++)
        {
            GameObject spawned = Instantiate(SpawnObject, SpawnParent.transform);
            Agent agent = spawned.GetComponent<Agent>();
            if (agent == null)
            {
                agent = spawned.AddComponent<Agent>();
            }

            agent.SetFaction(faction);
        }
    }
    
    // Update is called once per frame
    void Update ()
    {
        float time = Time.time;

        if (time - TimeAtLastSpawn > SpawnPeriod)
        {
            Spawn();
            TimeAtLastSpawn = time;
        }
        
    }
}
