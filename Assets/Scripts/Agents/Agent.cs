using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Agents;
using UnityEngine;

public class Agent : MonoBehaviour
{
    private Faction _faction;
    public Faction Faction
    {
        get { return this._faction; }
    }
    
    // Use this for initialization
    void Start ()
    {
        _faction = null;
    }

    void SetFaction(Faction faction)
    {
        this._faction = faction;

        ApplyFactionColor();
    }

    void ApplyFactionColor()
    {
        List<Renderer> renderers = new List<Renderer>();
        renderers.AddRange(GetComponents<Renderer>());
        renderers.AddRange(GetComponentsInChildren<Renderer>());

        for (int i = 0; i < renderers.Count; i++)
        {
            Renderer renderer = renderers[i];
            Material material = renderer.material;
            material.color = this.Faction.FactionColor;
        }
    }
    
    // Update is called once per frame
    void Update () {
        
    }
}
