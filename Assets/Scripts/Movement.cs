using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Movement : MonoBehaviour {

    private GameObject agentObject;

    // Update is called once per frame
    public void MoveTo(bool move, Vector3 goal)
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (move)
        {
            Debug.Log("Moving");
            agent.destination = goal;
        }
        else
        {
        }
        
    }
}
