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
    public float SpawnRadius;
    
    private float TimeAtLastSpawn;
    
    // Use this for initialization
    void Start ()
    {
        TimeAtLastSpawn = Time.time - SpawnPeriod;
    }

    void Spawn()
    {
        int spawnDimN = (int)Mathf.Ceil(Mathf.Sqrt(NumSpawns)); // spawn within a rectangle
        float spawnDim = spawnDimN * SpawnRadius;
        
        for (int i = 0; i < spawnDimN; i++)
        for (int j = 0; j < spawnDimN; j++)
        {
            Vector3 posOffset = Vector3.zero + (SpawnRadius * i - spawnDim / 2) * Vector3.forward + 
                          (SpawnRadius * j - spawnDim / 2) * Vector3.right;
            
            GameObject spawned = Instantiate(SpawnObject, SpawnParent.transform);
            spawned.transform.position = this.transform.position + posOffset;
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
