using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Vector3 startingPos;
    private Vector3 roamingPos;

    private void Start()
    {
        startingPos = transform.position;
        roamingPos = GetRoamingPos();
    }
    private Vector3 GetRoamingPos()
    {
        return startingPos + new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized * Random.Range(10f, 70f);
    }
}
