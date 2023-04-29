using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform LevelEnd;
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        if (!LevelEnd)
        {
            LevelEnd = GameObject.FindGameObjectWithTag("LevelEnd").transform;
        }
        agent.destination = LevelEnd.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
