using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void OnHit(float damage)
    {
        Debug.Log("Damage received: " + "[" + damage + "]");
    }
}
