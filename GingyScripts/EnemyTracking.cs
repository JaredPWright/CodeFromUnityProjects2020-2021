using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTracking : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent NavMeshA;
    public Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        //playerPos = GameObject.Find("Grungy").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        SetDestination();
    }

    void SetDestination()
    {
        Vector3 targetVector = playerPos.transform.position;
        NavMeshA.SetDestination(targetVector);
    }
}
